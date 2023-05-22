import json
import logging
from json import JSONDecodeError
from datetime import datetime
from fastapi import Request
from fastapi.responses import JSONResponse
from fastapi import FastAPI 
from resources.get_data_sql import get_data_from_sql
app = FastAPI()

@app.get("/")
async def main():
    """_summary_

    Returns:
        _type_: _description_
    """
    return {"code":0, "data":"success"}


@app.post("/getData")
async def get_data(request: Request):
    """_summary_
    {
        "Type": "sql/kql",
        "Query":""
    }

    Returns:
        _type_: _description_
    """
    try:
        req_body = await request.json()
        logging.warning(req_body)
        res=None
        if "Type" in req_body:
            if req_body["Type"] == "sql":
                response = get_data_from_sql(req_body)
                content=None
                if response["status"] == 0:
                    content = {"data":response["data"]}
                    return JSONResponse(
                        status_code=200,
                        content=content                
                    )
                elif response["status"] == -1:
                    content = response["data"]
                    return JSONResponse(
                        status_code=400,
                        content={"data":content}                
                    )
            elif req_body["Type"] == "kql":
                response = get_data_from_sql(req_body)
                return JSONResponse(
                    status_code=200,
                    content=response
                )
        return JSONResponse(
            status_code=400,
            content=res
        )

    except JSONDecodeError:
        res = {
            "code": -1,
            "msg": "Invalid Body"
        }
        return JSONResponse(
            status_code=400,
            content=res
        )

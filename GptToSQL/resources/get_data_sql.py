import json
import logging
from datetime import datetime
from shared_code.adapter_sql import execute_read_sql_query

def get_data_from_sql(json_data):
    """_summary_

    Args:
        json_data (_type_): _description_
    """
    if "Query" in json_data:
        res = execute_read_sql_query(json_data["Query"])
        return res
    
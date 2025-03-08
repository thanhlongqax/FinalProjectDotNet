import axiosConfig from '../config/axiosConfig'

class TableService {

    getTableById (tableId) {
       return axiosConfig.get("/api/table/" + tableId );
    }
    getTableAll(){
        return axiosConfig.get("/api/table");
    }
    createTable(payload){
        return axiosConfig.post("/api/table",payload);
    }
    updateTable(tableId ,payload){
        return axiosConfig.put("/api/table/" + tableId,payload );
    }
    deleteTable(tableId){
        return axiosConfig.delete("/api/table/" + tableId);
    }
}

const tableService = new TableService();
export default tableService;
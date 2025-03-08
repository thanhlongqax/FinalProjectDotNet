import axiosConfig from '../config/axiosConfig'

class ReservationService {

    getReservationById (reservationId) {
       return axiosConfig.get("/api/reservation/" + reservationId );
    }
    getReservationAll(){
        return axiosConfig.get("/api/reservation");
    }
    createReservation(payload){
        return axiosConfig.post("/api/reservation",payload);
    }
    updateReservation(reservationId , payload){
        return axiosConfig.put("/api/reservation/" + reservationId ,payload );
    }
    deleteReservation(reservationId){
        return axiosConfig.delete("/api/reservation/" + reservationId);
    }
}

const reservationService = new ReservationService();
export default reservationService;
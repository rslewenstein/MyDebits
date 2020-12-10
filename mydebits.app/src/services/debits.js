import { http } from './config'

export default{

    list:() => {
        return http.get('debit')
    },

    save:(debit) => {
        return http.post('debit', debit)
    }
}
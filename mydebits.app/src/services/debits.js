import { http } from './config'

export default{

    list:() => {
        return http.get('debit')
    },

    save:(deb) => {
        return http.post('debit', deb)
    }
}

<template>
  <div id="app">

    <nav>
      <div class="nav-wrapper orange darken-1">
        
        <a href="#" class="brand-logo center">MyDebits</a>
      </div>
    </nav>

    <div class="container">

      <form>

          <!-- <label>Nome</label> -->
          <input type="text" placeholder="Description">
          <!-- <label>Quantidade</label> -->
          <input type="text" placeholder="Category">
          <!-- <label>Valor</label> -->
          <input type="date" placeholder="Date">
          <input type="number" placeholder="Value">
          <input type="text" placeholder="Payment Method">
          <input type="text" placeholder="Quota">

          <button class="waves-effect waves-light btn-small">Save<i class="material-icons left">save</i></button>

      </form>
        <br />
      <table>

        <thead>

          <tr>
            <th>Description</th>
            <th>Category</th>
            <th>Date</th>
            <th>Value</th>
            <th>Payment Method</th>
            <th>Quota</th>
          </tr>

        </thead>

    <tbody>
      <tr v-for="deb of debits" :key="deb.id">
        <td>{{deb.description}}</td>
        <td>{{deb.categoryId}}</td>
        <td>{{deb.dateDebit}}</td>
        <td>{{deb.debitValue}}</td>
        <td>{{deb.paymentMethodId}}</td>
        <td>{{deb.quota}}</td>
        <td>
          <button class="waves-effect btn-small blue darken-1"><i class="material-icons">create</i></button>
          <button class="waves-effect btn-small red darken-1"><i class="material-icons">delete_sweep</i></button>
        </td>
      </tr>
    </tbody>
      
      </table>

    </div>

  </div>
</template>

<script>

import Debit from './services/debits'
export default {
  
  data(){
    return {
      debits: []
    }
  },

  mounted(){
    Debit.list().then(respost => {
      console.log(respost.data)
      this.debits = respost.data
    })
  }
}
</script>

<style>

</style>
<template>
  <div class="container">
    <div class="row" style="height:50px;">
    </div>
    <div class="row">
      <div class="col-12 d-flex flex-column">
        <div v-for="item in Status" :key="item.index" class="col-12 mt-2">
          <div
            class="alert alert-primary alert-dismissible fade show col-12"
            role="alert"
            v-if="Status.length"
          >
            <p>{{item}}</p>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-if="List.length > 0 && !Loading" class="overflow-auto myShadow">
      <table class="table table-hover border">
        <tr>
          <th scope="col">Name</th>
          <th scope="col">Email</th>
          <th scope="col">Fone</th>
          <th scope="col">Job</th>
          <th scope="col">Actions</th>
        </tr>
        <tbody>
          <tr v-for="item in List" :key="item.index">
            <td>{{item.name}}</td>
            <td>{{item.email}}</td>
            <td>{{item.phone}}</td>
            <td>{{item.job}}</td>
            <td>
              <button class="btn btn-danger mr-2 mt-1 mb-1" @click="deleteRegister(item.registerId)" v-if="item.registerId != 1">Delete</button>
              <a href="http://devfelipe.com" target="_blank" v-else>devfelipe.com</a>
              <button class="btn btn-primary mt-1 mb-1" @click="getToUpdate(item.registerId)" v-if="item.registerId != 1">Edit</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="d-flex justify-content-center" v-else>
      <img src="../assets/103.gif" />
    </div>
  </div>
</template>

<script>
export default {
  name: "Peoples",
  data() {
    return {
      List: [{}],
      id: 0,
      Status: [],
      Loading: true,
      name: null,
      email: null,
      phone: null,
      job: null,
      errors: []
    };
  },
  methods: {
    listAllRegisters() {
      //this.axios.get("https://crudvuejs.azurewebsites.net/api/Register").then(response => {
       this.axios.get("https://localhost:5001/api/Register").then(response => {
        if (response.data) {
          this.List = response.data;
          if (this.List.length > 0) {
            this.Loading = false;
          }
        }
      });
    },

    deleteRegister(obj) {
      this.id = obj;
      console.log(this.id);
      this.axios
        .delete("https://crudvuejs.azurewebsites.net/api/Register/" + this.id)
        // .delete("https://localhost:5001/api/Register/" + this.id)
        .then(response => {
          switch (response.data) {
            case 2:
              this.listAllRegisters();
              this.Status.push("I created the system, you can not delete me, try with another ... U.U");
              break;

            case 1:
              this.listAllRegisters();
              this.Status.push("Deleted with success!");
              break;

            case 0:
              this.Status.push("Error, try again... :C");
              break;
          }
        });
    },

    getToUpdate(obj) {
      this.$router.push({name: 'Update', query: { id: obj } });
    }
  },
  mounted() {
    this.listAllRegisters();
  }
};
</script>

<style>
</style>
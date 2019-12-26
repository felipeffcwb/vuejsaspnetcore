<template>
  <div class="container">
    <div class="row" style="height:50px;">
    </div>
    <div class="card myShadow">
      <article class="card-body mx-auto col-12" >
        <div v-for="item in errors" :key="item.index" class="col-12">
          <div
            class="alert alert-primary alert-dismissible fade show col-12"
            role="alert"
            v-if="errors.length"
          >
            <p>{{item}}</p>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
        </div>
        <h4 class="card-title mt-3 text-left">Update people</h4>
        <div v-if="!Loading">
          <form @submit="updateRegister" class="col-lg-8 col-md-12">
            <div class="form-group input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <font-awesome-icon icon="user" />
                </span>
              </div>
              <input
                name="name"
                class="form-control"
                placeholder="Full name"
                type="text"
                v-model="name"
                required
              />
            </div>
            <!-- form-group// -->
            <div class="form-group input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <font-awesome-icon icon="envelope" />
                </span>
              </div>
              <input
                name="email"
                class="form-control"
                placeholder="Email address"
                type="email"
                v-model="email"
                required
              />
            </div>
            <!-- form-group// -->
            <div class="form-group input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <font-awesome-icon icon="phone" />
                </span>
              </div>
              <input
                name="phone"
                class="form-control"
                placeholder="Phone number"
                type="text"
                v-model="phone"
                required
              />
              <input type="hidden" v-model="inputId" disabled />
            </div>
            <!-- form-group// -->
            <div class="form-group input-group">
              <div class="input-group-prepend">
                <span class="input-group-text">
                  <font-awesome-icon icon="briefcase" />
                </span>
              </div>
              <select name="job" class="form-control" v-model="job" required>
                <option selected>Select job type</option>
                <option>Designer</option>
                <option>Manager</option>
                <option>Accaunting</option>
              </select>
            </div>
            <!-- form-group end.// -->

            <!-- form-group// -->
            <div class="form-group">
              <button type="submit" class="btn btn-success btn-block">Update!</button>
            </div>
          </form>
        </div>
        <div class="d-flex justify-content-center" v-else>
            <img src="../assets/103.gif" />
        </div>
      </article>
    </div>
    <!-- card.// -->
  </div>
</template>

<script>
export default {
  name: "Update",
  data() {
    return {
      name: null,
      email: null,
      phone: null,
      job: null,
      inputId: null,
      errors: [],
      Loading: true
    };
  },
  methods: {
    updateRegister(e) {
      if (this.name && this.email && this.phone && this.job) {
        this.axios
          .put("https://crudvuejs.azurewebsites.net/api/Register/" + this.inputId, {
          // .put("https://localhost:5001/api/Register/" + this.inputId, {
            Name: this.name,
            Email: this.email,
            Phone: this.phone,
            Job: this.job,
            RegisterId: this.inputId
          })
          .then(response => {
            switch (response.data) {
              case false:
                this.errors.push("error, try again... :/");
                break;

              case true:
                this.errors.push("Ok, updated with success!");
                this.name = null;
                this.email = null;
                this.phone = null;
                this.job = null;
                setTimeout(() => this.$router.push("/Peoples"), 2000);
                break;
            }
            // this.errors.push(response.data);
          });
      }

      if (!this.name) {
        this.errors.push("Campo nome obrigatório");
      }

      if (!this.email) {
        this.errors.push("Campo email obrigatório");
      }

      if (!this.phone) {
        this.errors.push("Campo senha obrigatório");
      }

      if (!this.job) {
        this.errors.push("Campo confirmação obrigatório");
      }

      e.preventDefault();
      console.log(this.errors);
    }
  },
  beforeCreate() {
    this.axios
      .get("https://crudvuejs.azurewebsites.net/api/Register/" + this.$route.query.id)
      // .get("https://localhost:5001/api/Register/" + this.$route.query.id)
      .then(response => {
        if (response.data) {
          this.Loading = false;
          this.name = response.data.name;
          this.email = response.data.email;
          this.phone = response.data.phone;
          this.job = response.data.job;
          this.inputId = response.data.registerId;
        }
      });
  }
};
</script>

<style>
.btn-success {
  height: 60px;
}
</style>
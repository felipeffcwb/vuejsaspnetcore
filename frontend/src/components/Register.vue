<template>
  <div class="container myFade">
    <div class="row" style="height:50px;">
    </div>
    <div class="card myShadow">
      <article class="card-body mx-auto col-12">
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
        <h4 class="card-title mt-3 text-left">Insert people</h4>
        <form @submit="submitRegister" class="col-lg-8 col-md-12">
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
              v-mask="mask"
              required
            />
          </div>
          <!-- form-group// -->
          <div class="form-group input-group">
            <div class="input-group-prepend">
              <span class="input-group-text">
                <font-awesome-icon icon="briefcase" />
              </span>
            </div>
            <select name="job" class="form-control" v-model="job" required>
              <option disabled selected>Select job type</option>
              <option>Designer</option>
              <option>Manager</option>
              <option>Accaunting</option>
            </select>
          </div>
          <!-- form-group end.// -->

          <!-- form-group// -->
          <div class="form-group">
            <button type="submit" class="btn btn-success btn-block">Insert People</button>
          </div>
        </form>
      </article>
    </div>
    <!-- card.// -->
  </div>
</template>

<script>
export default {
  name: "Register",
  data() {
    return {
      name: null,
      email: null,
      phone: null,
      job: null,
      errors: [],
      mask: "(##) #####-####"
    };
  },
  methods: {
    submitRegister(e) {
      if (this.name && this.email && this.phone && this.job) {
        this.axios
          .post("https://crudvuejs.azurewebsites.net/api/Register", {
          // .post("https://localhost:5001/api/Register", {
            Name: this.name,
            Email: this.email,
            Phone: this.phone,
            Job: this.job
          })
          .then(response => {
            switch (response.data) {
              case 0:
                this.errors.push(
                  "This people has been registered with this job, try with other options :)"
                );
                break;

              case 1:
                this.errors.push("The name field is necessary u.u");
                break;

              case 2:
                this.errors.push("The email field is necessary u.u");
                break;

              case 3:
                this.errors.push("The job field is necessary u.u");
                break;

              case 4:
                this.errors.push("Ok, you are registered ;)");
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
  }
};
</script>

<style>
input {
  height: 60px !important;
  border-radius: 12px;
}

select {
  height: 60px !important;
  border-radius: 12px;
}

.btn-sucess {
  height: 60px;
}
</style>
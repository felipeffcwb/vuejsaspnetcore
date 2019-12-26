<template>
  <div id="app" >
    <Nav />
    <div class="container-fluid">
    <div class="row fullRow">
        <div class="col-lg-6 col-md-3 bgImage d-flex justify-content-center align-items-center flex-column">
          <div class="p-3 bg-light myShadowHd" style="border-radius:6px;" id="myTitle">
            <h1 class="text-center">Vue Js && Bootstrap + <br> ASP.Net Core + <br> Entity && SQL</h1>
          </div>
        </div>
        <div class="col-lg-6 col-md-9">
        <router-view class="containerHeight">
          <Register class="myFade" />
          <Peoples class="myFade"/>
          <Update class="myFade"/>
        </router-view>
        <Footer/>
        </div>
    </div>
  </div>
    <!-- <Footer /> -->
  </div>
</template>

<script>
import Register from "./components/Register.vue";
import Nav from "./components/Nav.vue";
import Peoples from "./components/Peoples.vue";
import Footer from "./components/Footer.vue";
import Update from "./components/Update.vue";

export default {
  name: "app",
  components: {
    Register,
    Nav,
    Peoples,
    Update,
    Footer
  }
};
</script>

<style>
@import "./assets/css/style.css";
.containerHeight {
  min-height: 75vh;
}
.svg-lg{
  font-size: 200px;
  color:#41B883;
}

@media screen and (max-width: 1000px) {
    .svg-lg {
      display: none !important;
    }

    #myTitle {
      display:none !important;
    }
}
</style>

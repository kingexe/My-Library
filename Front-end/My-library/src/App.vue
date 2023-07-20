<script setup>
import { RouterView } from 'vue-router';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap-vue/dist/bootstrap-vue.min.css';


</script>

<template>

    <header>
    <nav class="navbar navbar-expand-lg navbar-light" style="background-color: #e3f2fd;">
      <div class="container">
        <a class="navbar-brand" href="#">Library Management</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
          aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <router-link class="nav-link" to="/Addbook">Add Book</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/ListBook">List Books</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>

 <RouterView />

<Footer />

  
</template>

<style scoped>

</style>

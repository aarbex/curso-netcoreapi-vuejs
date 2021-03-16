<template>
  <div id="app">
    <Nav/>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
    
  </div>
</template>

<script>
// import Alunos from './components/Aluno/Alunos.vue'
import Nav from './components/_nav/Nav'
// import Professores from './components/Professor/Professores'
// import Sobre from './components/Sobre/Sobre'

export default {
  name: 'App',
  components: {
    // Alunos,
    Nav,
    // Professores,
    //Sobre
  }
}
</script>

<style>

@import url('https://fonts.googleapis.com/css2?family=Montserrat&display=swap');
.marginPrincipal{
     width: 50%;
     margin: auto;
 }
body{
  background-color: #eee;
  font-family: "Montserrat", sans-serif;
  display: grid;
  justify-items: center;
}

body, html{
  margin: 0;
  height: 100%;
}

table{
  margin: 0;
  padding: 0;
  list-style-type: none;
  width: 100%;
}
table tr td{
  padding: 20px;
  font-size: 1.3em;
  background-color: #e0edf4;
  margin-bottom: 2px;
  color: #3e5252;
}
table thead th{
  background-color: rgb(184, 208, 216) !important;
  font-size: 1.2em;
  padding: 10px, 0px;
  text-align: center !important;
}

.colPequeno{
  width: 5%;
  text-align: right;
  background-color: rgb(125,217,245);
  font-weight: bold;
}

.btn_danger{
  font-size: 0.8em !important;
   background-color: #fa4430;
}

.btn{ 
  padding: 10px 20px;
  border: 1px solid #000;
  cursor: pointer;
  font-size: 1.2em;
  color: white;
  font-weight: bold;
  border-radius: 5px;
  border-bottom: 3px solid black;
}

.btn:hover{
  text-shadow: 1px 1px 1px black;
  margin-top: 3px;
  border-bottom: 1px solid black;
}

#app {
  width: 100%;
}
</style>

<template>
  <div id="app">
    <HelloWorld msg="Welcome to Your Vue.js App"/>
    <TheHeader/>
    <TheNavBar/>
    <TheContent/>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import TheHeader from './components/layout/TheHeader.vue'
import TheNavBar from './components/layout/TheNavBar.vue'
import TheContent from './components/layout/TheContent.vue'

export default {
  name: 'App',
  components: {
    HelloWorld,
    TheHeader,
    TheNavBar,
    TheContent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>

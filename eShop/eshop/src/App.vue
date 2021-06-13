<template>
  <div id="app">
    <TheHeader/>
    <TheNavBar/>
    <TheContent/>
  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue'
import TheNavBar from './components/layout/TheNavBar.vue'
import TheContent from './components/layout/TheContent.vue'

export default {
  name: 'App',
  components: {
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
}
</style>

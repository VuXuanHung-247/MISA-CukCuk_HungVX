<template>
  <div id="content">
    <StoreList/>
  </div>
</template>

<script>
import StoreList from '../views/StoreList.vue'
export default {
  components: {
    StoreList
  }
}
</script>

<style>
@import '../../style/layout/content.css'
</style>
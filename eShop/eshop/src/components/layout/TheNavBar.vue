<template>
    <div id="navbar">
        <div class="logo">
        </div>
        <div class="menu">
            <div class="menu-item" v-for="navbar in navbars" :key="navbar.icon">
                <div class="menu-item-logo" :class="navbar.icon"></div>
                <div class="menu-item-title">{{navbar.text}}</div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
     data(){
            return{
                navbars:[
                    {"icon":"dashboard","text":"Tổng quan"},
                    {"icon":"report","text":"Báo cáo"},
                    {"icon":"order","text":"Đơn hàng"},
                    {"icon":"pu","text":"Mua hàng"},
                    {"icon":"sale","text":"Khuyến mại"},
                    {"icon":"manage","text":"Quản lý cửa hàng"},
                    {"icon":"goods","text":"Hàng hóa"},
                ]
            }
        }
}
</script>

<style>
@import '../../style/layout/navbar.css'
</style>
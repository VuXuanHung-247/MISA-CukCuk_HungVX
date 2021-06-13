<template>
  <div class="content-body">
    <div class="toolbar">
      <div class="toolbar-item" v-for="tool in tools" :key="tool.icon">
        <div class="toolbar-item-logo" :class="tool.icon"></div>
        <div class="toolbar-item-title" :class="tool.title">{{tool.text}}</div>
      </div>
    </div>
    <div class="gird"></div>
  </div>
</template>

<script>
export default {
  data(){
            return{
                tools:[
                    {"icon":"add","title":"add-title","text":"Thêm mới"},
                    {"icon":"duplicate","title":"duplicate-title","text":"Nhân bản"},
                    {"icon":"update","title":"update-title","text":"Sửa"},
                    {"icon":"delete","title":"delete-title","text":"Xóa"},
                    {"icon":"refresh","title":"refresh-title","text":"Nạp"},
                ]
            }
        }
};
</script>

<style>
@import "../../style/view/storelist.css";
</style>
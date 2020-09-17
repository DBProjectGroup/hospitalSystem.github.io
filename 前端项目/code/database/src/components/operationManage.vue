<template>
  <el-container class="manage-container">
    <!-- 头部 -->
    <el-header>
      <div class="avator_box">
        <span>手术管理系统</span>
      </div>
      <el-button type="info" @click="logout">退出</el-button>
    </el-header>
    <!-- 页面主体 -->
    <el-container>
      <!-- 侧边栏 -->
      <el-aside width="200px">
        <!-- 侧边栏菜单区域 -->
        <el-menu background-color="#545c64" text-color="#fff" active-text-color="#409EFF" :router='true'>
          <!-- 一级菜单 -->
          <el-submenu index="1">
            <!-- 一级菜单的模版区域 -->
            <template slot="title">
              <!-- 图标 -->
              <i class="el-icon-first-aid-kit"></i>
              <!-- 文本 -->
              <!-- <span>{{item.authName}}</span> -->
              <span>手术管理</span>
            </template>
            <el-menu-item-group>
              <!-- 二级菜单 -->
              <el-menu-item index="operationList">
                <template slot="title">
                  <i class="el-icon-menu"></i>
                  <span>手术安排</span>
                </template>
              </el-menu-item>
              <el-menu-item index="operationOrder">
                <template slot="title">
                  <i class="el-icon-menu"></i>
                  <span>手术安排</span>
                </template>
              </el-menu-item>
            </el-menu-item-group>
          </el-submenu>
        </el-menu>
      </el-aside>
      <!-- 右侧内容 -->
      <el-main>
        <!-- 路由占位符 -->
        <router-view> </router-view>
      </el-main>
    </el-container>
  </el-container>
</template>

<script>
export default {
  data () {
    return {
      // 左侧菜单数据
      menulist: []
    }
  },
  methods: {
    // created () {
    //   this.getMenuList
    // },
    logout () {
      this.$router.push('/Login')
    },
    getMenuList () {
      this.$http.post('').then((res) => {
        console.log(res.data)
        if (res.data === '') {
          return this.$message.error()
        }
      })
    }
  }
}
</script>

<style>
.manage-container {
  height: 100%;
}
.el-header {
  background-color: #373d41;
  color: #333;
  display: flex;
  justify-content: space-between;
  padding-left: 0;
  align-items: center;
  text-align: center;
  line-height: 60px;
  color: #fff;
  font-size: 20px;
}
.el-aside {
  background-color: #545c64;
  color: #333;
  text-align: center;
  line-height: 200px;
}

.el-main {
  background-color: #e9eef3;
  color: #333;
  text-align: center;
}
</style>

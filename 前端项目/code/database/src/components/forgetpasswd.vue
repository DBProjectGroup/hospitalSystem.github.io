<template>
  <div class="forget_container">
    <img src="../assets/timg.jpeg" alt />
    <div class="forget_box">
      <div class="avator_box">
        <img src="../assets/timg.jpg" />
      </div>
      <h1>
        <strong>找回密码</strong>
      </h1>
      <el-form ref="forgetFormRef" :model="forgetForm" :rules="forgetFormRules" label-width="0px" class="forget_form">
        <el-form-item class="id_input" prop="username">
          <el-input prefix-icon="iconfont icon-xingming" v-model="forgetForm.username"></el-input>
        </el-form-item>
        <el-form-item class="name_input" prop="name">
          <el-input prefix-icon="iconfont icon-yonghu" v-model="forgetForm.name"></el-input>
        </el-form-item>
        <el-form-item class="forget_btn">
          <el-button type="primary" @click="forget">找回密码</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      // 数据绑定对象
      forgetForm: {
        username: '003',
        name: '张三'
      },
      // 验证规则对象
      forgetFormRules: {
        username: [
          {
            required: true,
            message: '请输入用户ID',
            trigger: 'blur'
          },
          {
            min: 1,
            max: 10,
            message: '长度是 1 到 10 个字符',
            trigger: 'blur'
          }
        ],
        name: [
          {
            required: true,
            message: '请输入用户姓名',
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    forget () {
      this.$refs.forgetFormRef.validate((valid) => {
        this.$http
          .post('https://localhost:44347/Home/Login', this.forgetForm)
          .then((res) => {
            console.log('信息正确')
            console.log(res.data)
            if (res.data !== '') {
              return this.$message.success('信息正确！')
            }
          })
          .catch((res) => {
            console.log('信息错误')
            return this.$message.error('请确认信息')
          })
      })
    }
  }
}
</script>

<style lang="less" scoped>
.forget_container {
  background-color: #2b2b2b;

  img {
    width: 100%;
    height: 100%;
  }
}
.avator_box {
  height: 130px;
  width: 130px;
  border: 1px solid #eee;
  border-radius: 50%;
  padding: 10px;
  box-shadow: 0 0 10px #ddd;
  position: absolute;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: #fff;

  img {
    height: 100%;
    width: 100%;
    border-radius: 50%;
    background-color: #eee;
  }
}
.forget_box {
  width: 350px;
  height: 400px;
  background-color: #e4eef7;
  border-radius: 5px;
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
  display: block;

  h1 {
    border: 1px solid #eeeeee;
    padding: 10px;
    position: absolute;
    left: 28%;
    top: 20%;
    color: black;
  }
}
.forget_form {
    position: absolute;
    bottom: 0;
    width: 100%;
    padding: 0 20px;
    box-sizing: border-box;
}
.forget_btn {
    display: flex;
    justify-content: flex-end;
    position: relative;
    left: -100px;
    top: 10px;
}
</style>

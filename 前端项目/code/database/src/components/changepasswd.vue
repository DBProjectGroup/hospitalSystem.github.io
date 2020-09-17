<template>
  <div class="change_container">
    <img src="../assets/timg.jpeg" alt />
    <div class="change_box">
      <div class="avator_box">
        <img src="../assets/timg.jpg" />
      </div>
      <h1>
        <strong>修改密码</strong>
      </h1>
      <el-form
        ref="verifyFormRef"
        :model="verifyForm"
        status-icon
        :rules="verifyFormRules"
        label-width="0px"
        class="verify_form"
      >
        <el-form-item class="id_input" prop="username">
          <el-input prefix-icon="iconfont icon-xingming" v-model="verifyForm.username"></el-input>
        </el-form-item>
        <el-form-item class="name_input" prop="name">
          <el-input prefix-icon="iconfont icon-yonghu" v-model="verifyForm.name"></el-input>
        </el-form-item>
        <el-form-item prop="pass">
          <el-input
            prefix-icon="iconfont icon-mima"
            type="password"
            v-model="verifyForm.pass"
            autocomplete="off"
          ></el-input>
        </el-form-item>
        <el-form-item prop="checkPass">
          <el-input
            prefix-icon="iconfont icon-mima"
            type="password"
            v-model="verifyForm.checkPass"
            autocomplete="off"
          ></el-input>
        </el-form-item>
        <el-form-item class="change_btn">
          <el-button type="primary" @click="change">修改密码</el-button>
        </el-form-item>
      </el-form>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    var validatePass = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请输入密码'))
      } else {
        callback()
      }
    }
    var validatePass2 = (rule, value, callback) => {
      if (value === '') {
        callback(new Error('请再次输入密码'))
      } else if (value !== this.verifyForm.pass) {
        callback(new Error('两次输入密码不一致!'))
      } else {
        callback()
      }
    }
    return {
      verifyForm: {
        username: '003',
        name: '张三',
        pass: '',
        checkPass: ''
      },
      verifyFormRules: {
        username: [
          { required: true, message: '请输入用户ID', trigger: 'blur' }
        ],
        name: [
          { required: true, message: '请输入用户姓名', trigger: 'blur' }
        ],
        pass: [
          { validator: validatePass, trigger: 'blur' }
        ],
        checkPass: [
          { validator: validatePass2, trigger: 'blur' }
        ]
      }
    }
  },
  methods: {
    change () {
      this.$refs.verifyFormRef.validate((valid) => {
        this.$http
          .post('https://localhost:44347/Home/Login', this.loginForm)
          .then((res) => {
            console.log('成功修改密码')
            console.log(res.data)
            if (res.data !== '') {
              return this.$message.success('密码修改成功')
            }
          })
          .catch((res) => {
            console.log('修改失败，请检查信息')
            return this.$message.error('修改密码失败')
          })
      })
    }
  }
}
</script>

<style lang="less" scoped>
.change_container {
  background-color: #2b4b6b;
  height: 100%;
  img {
    height: 100%;
    width: 100%;
  }
}
.change_box {
  width: 350px;
  height: 500px;
  background-color: #e4eef7;
  border-radius: 3px;
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
    top: 18%;
    color: black;
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
.verify_form {
  position: absolute;
  bottom: 0;
  width: 100%;
  padding: 0 20px;
  box-sizing: border-box;
}
.change_btn {
  display: flex;
  justify-content: flex-end;
  position: relative;
  left: -115px;
  top: 10px;
}
</style>

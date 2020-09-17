<template>
    <div class="login_container">
        <img src="../assets/timg.jpeg" alt="">
        <div class="login_box">
            <!-- 头像区域 -->
            <div class="avator_box">
                <img src="../assets/timg.jpg">
            </div>
            <h1>
                <strong>统一身份认证</strong>
            </h1>
            <!-- 登陆表单区域 -->
            <el-form ref="loginFormRef" v-bind:model="loginForm" :rules="loginFormRules" label-width="0px" class="login_form">
                <!-- 用户ID -->
                <el-form-item class="id_input" prop="ID">
                    <el-input prefix-icon="iconfont icon-yonghu" v-model='loginForm.ID'></el-input>
                </el-form-item>
                <!-- 用户密码 -->
                <el-form-item class="passwd_input" prop="pass">
                    <el-input prefix-icon="iconfont icon-mima" v-model='loginForm.pass' type="password"></el-input>
                </el-form-item>
                <!-- 登陆按钮 -->
                <el-form-item class="login_btn">
                    <el-button type="primary" @click="login">登陆</el-button>
                </el-form-item>
                <!-- 忘记密码 -->
                <el-form-item class="passwd_link">
                    <el-link type="primary" @click="changepasswd">| 忘记密码 |</el-link>
                </el-form-item>
                <div class="help">
                    <p>如有需要请拨打123456</p>
                </div>
            </el-form>
            <div @click="signUp">注册</div>
        </div>
    </div>
</template>

<script>
export default {
  data () {
    return {
      // 这是登陆表单的数据绑定对象
      loginForm: {
        ID: '',
        pass: ''
      },
      // 这是表单的验证规则对象
      loginFormRules: {
        // 验证用户名是否合法
        username: [
          {
            required: true, message: '请输入用户ID', trigger: 'blur'
          },
          {
            min: 1, max: 10, message: '长度是 10 个字符', trigger: 'blur'
          }
        ],
        // 验证密码是否合法
        password: [
          {
            required: true, message: '请输入用户ID', trigger: 'blur'
          },
          {
            min: 6, max: 20, message: '长度在 6 个字符以上', trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    login () {
      this.$refs.loginFormRef.validate((valid) => {
        this.$http.post('https://localhost:44347/Home/Login',
          this.loginForm
        ).then(res => {
          console.log('成功')
          console.log(res.data)
          if (res.data !== '') {
            window.sessionStorage.setItem('token', res.data.token)
            return this.$message.success('登陆成功')
            // eslint-disable-next-line no-unreachable
            this.$router.push('/home')
          }
          return this.$message.error('登陆失败')
          // eslint-disable-next-line no-unreachable
        }).catch(res => {
          console.log('失败')
          console.log(res)
          return this.$message.error('登陆失败')
        })
        // if (res.meta.status !== 200) return this.$message.error('登陆失败')
        // this.$message.success('登陆成功')
        // 1. 将登陆成功后的token保存到客户端的 sessionStorage 中
        //  1.1 项目中除了登陆之外的其他API接口，必须在登录之后访问
        //  1.2 token只应在当前网站打开期间生效，所以将 token 保存在 sessionStorage 中
        // window.sessionStorage.setItem('token', res.data.token)
        // 2. 通过编程式导航跳转到后台主页，路由地址是 /home
        // this.$router.push('/home')
      })
    },
    changepasswd () {
      this.$router.push('/changepasswd')
    },
    forgetpasswd () {
      this.$router.push('/forgetpasswd')
    },
    signUp () {
      this.$router.push('/signUp')
    }
  }
}
</script>

<style lang="less" scoped>
.login_container{
     background-color: #2b4b6b;
     height: 100%;
     img {
         height: 100%;
         width: 100%;
     }
}
.login_box {
    width: 350px;
    height: 400px;
    background-color: #e4eef7;
    border-radius: 10px;
    position: absolute;
    left: 50%;
    top: 50%;
    transform: translate(-50%, -50%);
    display: block;

    .avator_box{
        height: 130px;
        width: 130px;
        border: 1px solid #eee;
        border-radius: 50%;
        padding: 10px;
        box-shadow:0 0 10px #ddd ;
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

    h1 {
        border: 1px solid #eeeeee;
        padding: 10px;
        position: absolute;
        left: 20%;
        top: 20%;
        color: black;
    }
}

.login_form {
    position: absolute;
    bottom: 0;
    width: 100%;
    padding: 0 20px;
    box-sizing: border-box;
    img {
        border: none;
        max-width: 100%;
    }
}
.login_btn {
    display: flex;
    justify-content: flex-end;
    position: relative;
    left: -119px;
    top: 25px;
}
.id_input {
    position: relative;
    top: 45px;
}
.passwd_input {
    position: relative;
    top: 40px
}
.passwd_link {
    display: flex;
    justify-content: flex-end;
}
.help p {
    margin: 0;
    padding: 20px 0 0 0;
    color: black;
    font-size: 11px;
}
</style>

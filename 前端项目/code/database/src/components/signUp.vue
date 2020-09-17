<template>
  <div class="login-wrap">
    <div class="login-html">
      <input id="tab-1" type="radio" name="tab" class="sign-in" checked />
      <label for="tab-1" class="tab">医生注册</label>
      <input id="tab-2" type="radio" name="tab" class="sign-up" />
      <label for="tab-2" class="tab">护士注册</label>
      <input id="tab-3" type="radio" name="tab" class="sign-up-admin" />
      <label for="tab-3" class="tab">管理员注册</label>
      <div
        class="login-form"
      >
        <div class="sign-in-htm" v-bind:model="doctorForm" ref="doctorFormRef" :rules="doctorFormRules">
          <div class="group">
            <label for="user" class="label" prop="username">医生ID</label>
            <input id="user" type="text" class="input" v-model="doctorForm.username" />
          </div>
          <div class="group">
            <label for="name" class="label" prop="name">医生姓名</label>
            <input id="name" type="text" class="input" v-model="doctorForm.name" />
          </div>
          <div class="group">
            <label for="password" class="label" prop="password">密码</label>
            <input id="password" type="text" class="input" v-model="doctorForm.password" />
          </div>
          <div class="group">
            <label for="dept_name" class="label" prop="dept_name">所属科室名称</label>
            <input id="dept_name" type="text" class="input" v-model="doctorForm.dept_name" />
          </div>
          <div class="group">
            <label for="position" class="label" prop="position">职位</label>
            <input id="position" type="text" class="input" v-model="doctorForm.position" />
          </div>
          <div class="group">
            <label for="age" class="label" prop="age">年龄</label>
            <input id="age" type="text" class="input" v-model="doctorForm.age" />
          </div>
          <div class="group">
            <label for="gender" class="label" prop="gender">性别</label>
            <input id="gender" type="text" class="input" v-model="doctorForm.gender" />
          </div>
          <div class="group">
            <label for="type" class="label" prop="type">用户类型</label>
            <input id="type" type="text" class="input" v-model="doctorForm.type" />
          </div>
          <div class="group">
            <input type="submit" @click="doctorSignUp" class="button" value="注册" />
          </div>
          <div class="hr"></div>
        </div>
        <div class="sign-up-htm" v-bind:model="nurseForm" ref="nurseFormRef" :rules="nurseFormRules">
          <div class="group">
            <label for="user" class="label" prop="nurseID">护士ID</label>
            <input id="user" type="text" class="input" v-model="nurseForm.nurseID" />
          </div>
          <div class="group">
            <label for="name" class="label" prop="nurseName">护士姓名</label>
            <input id="name" type="text" class="input" v-model="nurseForm.nurseName" />
          </div>
          <div class="group">
            <label for="password" class="label" prop="nursePassword">密码</label>
            <input id="password" type="text" class="input" v-model="nurseForm.nursePassword" />
          </div>
          <div class="group">
            <label for="gender" class="label" prop="nurseGender">护士性别</label>
            <input id="gender" type="text" class="input" v-model="nurseForm.nurseGender" />
          </div>
          <div class="group">
            <label for="dept_name" class="label" prop="nurseDept_name">所属科室名称</label>
            <input id="dept_name" type="text" class="input" v-model="nurseForm.nurseDept_name" />
          </div>
          <div class="group">
            <label for="position" class="label" prop="nursePosition">职位</label>
            <input id="positon" type="text" class="input" v-model="nurseForm.nursePosition" />
          </div>
          <div class="group">
            <label for="type" class="label" prop="nurseType">用户类型</label>
            <input id="type" type="text" class="input" v-model="nurseForm.nurseType" />
          </div>
          <div class="group">
            <input type="submit" class="button" @click="nurseSignUp" value="注册" />
          </div>
          <div class="hr"></div>
        </div>
        <div class="sign-up-admin-htm" v-bind:model="adminForm" ref="adminFormRef"
        :rules="adminFormRules">
          <div class="group">
            <label for="user" class="label" prop="adminID">管理员ID</label>
            <input id="user" type="text" class="input" v-model="adminForm.adminID" />
          </div>
          <div class="group">
            <label for="username" class="label" prop="adminName">管理员姓名</label>
            <input id="user" type="text" class="input" v-model="adminForm.adminName" />
          </div>
          <div class="group">
            <label for="password" class="label" prop="adminPassword">管理员密码</label>
            <input id="password" type="text" class="input" v-model="adminForm.adminPassword" />
          </div>
          <div class="group">
            <label for="type" class="label" prop="adminType">用户类型</label>
            <input id="type" type="text" class="input" v-model="adminForm.adminType" />
          </div>
          <div class="group">
            <input type="submit" class="button" @click="adminSignUp" value="注册" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data () {
    return {
      doctorForm: {
        username: '',
        name: '',
        password: '',
        dept_name: '',
        position: '',
        age: '',
        gender: '',
        type: ''
      },
      nurseForm: {
        nurseID: '',
        nurseName: '',
        nursePassword: '',
        nursePosition: '',
        nurseDept_name: '',
        nurseGender: '',
        nurseType: ''
      },
      adminForm: {
        adminID: '',
        adminName: '',
        adminPassword: '',
        adminType: ''
      },
      doctorFormRules: {
        username: [
          {
            required: true,
            message: '请输入医生ID',
            trigger: 'blur'
          },
          {
            min: 3,
            max: 10,
            message: '长度是 3 到 10 个字符',
            trigger: 'blur'
          }
        ],
        name: [
          {
            required: true,
            message: '请输入医生姓名',
            trigger: 'blur'
          },
          {
            min: 2,
            max: 10,
            message: '长度大于 2 个字符',
            trigger: 'blur'
          }
        ],
        password: [
          {
            required: true,
            message: '请输入密码',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 30,
            message: '长度大于 6 个字符',
            trigger: 'blur'
          }
        ],
        dept_name: [
          {
            required: true,
            message: '请输入科室的名称',
            trigger: 'blur'
          }
        ],
        position: [
          {
            required: true,
            message: '请输入医生的职位',
            trigger: 'blur'
          }
        ],
        age: [
          {
            required: true,
            message: '请输入年龄',
            trigger: 'blur'
          }
        ],
        gender: [
          {
            required: true,
            message: '请输入性别',
            trigger: 'blur'
          }
        ]
      },
      nurseFormRules: {
        nurseID: [
          {
            required: true,
            message: '请输入护士ID',
            trigger: 'blur'
          },
          {
            min: 2,
            max: 10,
            message: '长度在 2 到 10 个字符',
            trigger: 'blur'
          }
        ],
        nurseName: [
          {
            required: true,
            message: '请输入护士姓名',
            trigger: 'blur'
          },
          {
            min: 2,
            max: 10,
            message: '长度大于 2 个字符',
            trigger: 'blur'
          }
        ],
        nursePassword: [
          {
            required: true,
            message: '请输入密码',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 30,
            message: '长度大于 6 个字符',
            trigger: 'blur'
          }
        ],
        nursePosition: [
          {
            required: true,
            message: '请输入护士职位',
            trigger: 'blur'
          }
        ],
        nurseDept_name: [
          {
            required: true,
            message: '请输入科室的名称',
            trigger: 'blur'
          }
        ],
        nurseGender: [
          {
            required: true,
            message: '请输入性别',
            trigger: 'blur'
          }
        ]
      },
      adminFormRules: {
        adminID: [
          {
            required: true,
            message: '请输入管理员ID',
            trigger: 'blur'
          },
          {
            min: 3,
            max: 10,
            message: '长度是 3 到 10 个字符',
            trigger: 'blur'
          }
        ],
        adminName: [
          {
            required: true,
            message: '请输入管理员姓名',
            trigger: 'blur'
          },
          {
            min: 2,
            max: 10,
            message: '长度大于 2 个字符',
            trigger: 'blur'
          }
        ],
        adminPassword: [
          {
            required: true,
            message: '请输入密码',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 30,
            message: '长度大于 6 个字符',
            trigger: 'blur'
          }
        ]
      }
    }
  },
  methods: {
    doctorSignUp () {
      this.$http.post('http://localhost:44347/Home/Login', this.doctorForm
      ).then(res => {
        console.log('注册成功')
        this.$router.push('/Login')
        return this.$message.success('注册成功')
      }).catch(res => {
        console.log('注册失败')
        return this.$message.error('注册失败')
      })
    },
    nurseSignUp () {
      this.$http.post('http://localhost:44347/Home/Login', this.nurseForm
      ).then(res => {
        console.log('注册成功')
        this.$router.push('/Login')
        return this.$message.success('注册成功')
      }).catch(res => {
        console.log('注册失败')
        return this.$message.error('注册失败')
      })
    },
    adminSignUp () {
      this.$http.post('http://localhost:44347/Home/Login', this.adminForm
      ).then(res => {
        console.log('注册成功')
        this.$router.push('/Login')
        return this.$message.success('注册成功')
      }).catch(res => {
        console.log('注册失败')
        return this.$message.error('注册失败')
      })
    }
  }
}
</script>

<style>
*,
:after,
:before {
  box-sizing: border-box;
}
.clearfix:after,
.clearfix:before {
  content: "";
  display: table;
}
.clearfix:after {
  clear: both;
  display: block;
}
a {
  color: inherit;
  text-decoration: none;
}
.login-wrap {
  width: 100%;
  margin: auto;
  max-width: 525px;
  min-height: 800px;
  position: relative;
  box-shadow: 0 12px 15px 0 rgba(0, 0, 0, 0.24),
    0 17px 50px 0 rgba(0, 0, 0, 0.19);
}
.login-html {
  width: 100%;
  height: 100%;
  position: absolute;
  padding: 90px 70px 50px 70px;
  background: rgba(40, 57, 101, 0.9);
}
.login-html .sign-in-htm,
.login-html .sign-up-htm,
.login-html .sign-up-admin-htm {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  transform: rotateY(180deg);
  backface-visibility: hidden;
  transition: all 0.4s linear;
}
.login-html .sign-in,
.login-html .sign-up,
.login-html .sign-up-admin,
.login-form .group .check {
  display: none;
}
.login-html .tab,
.login-form .group .label,
.login-form .group .button {
  text-transform: uppercase;
}
.login-html .tab {
  font-size: 22px;
  margin-right: 15px;
  padding-bottom: 5px;
  margin: 0 15px 10px 0;
  display: inline-block;
  border-bottom: 2px solid transparent;
}
.login-html .sign-in:checked + .tab,
.login-html .sign-up:checked + .tab,
.login-html .sign-up-admin:checked + .tab {
  color: #fff;
  border-color: #1161ee;
}
.login-form {
  min-height: 345px;
  position: relative;
  perspective: 1000px;
  transform-style: preserve-3d;
}
.login-form .group {
  margin-bottom: 15px;
}
.login-form .group .label,
.login-form .group .input,
.login-form .group .button {
  width: 100%;
  color: #fff;
  display: block;
}
.login-form .group .input,
.login-form .group .button {
  border: none;
  padding: 15px 20px;
  border-radius: 25px;
  background: rgba(255, 255, 255, 0.1);
}
.login-form .group .label {
  color: #aaa;
  font-size: 12px;
}
.login-form .group .button {
  background: #1161ee;
}
.login-form .group label .icon {
  width: 15px;
  height: 15px;
  border-radius: 2px;
  position: relative;
  display: inline-block;
  background: rgba(255, 255, 255, 0.1);
}
.login-form .group label .icon:before,
.login-form .group label .icon:after {
  content: "";
  width: 10px;
  height: 2px;
  background: #fff;
  position: absolute;
  transition: all 0.2s ease-in-out 0s;
}
.login-form .group label .icon:before {
  left: 3px;
  width: 5px;
  bottom: 6px;
  transform: scale(0) rotate(0);
}
.login-form .group label .icon:after {
  top: 6px;
  right: 0;
  transform: scale(0) rotate(0);
}
.login-form .group .check:checked + label {
  color: #fff;
}
.login-form .group .check:checked + label .icon {
  background: #1161ee;
}
.login-form .group .check:checked + label .icon:before {
  transform: scale(1) rotate(45deg);
}
.login-form .group .check:checked + label .icon:after {
  transform: scale(1) rotate(-45deg);
}
.login-html
  .sign-in:checked
  + .tab
  + .sign-up
  + .tab
  + .sign-up-admin
  + .tab
  + .login-form
  .sign-in-htm {
  transform: rotate(0);
}
.login-html .sign-up:checked + .tab + .sign-up-admin + .tab + .login-form .sign-up-htm {
  transform: rotate(0);
}
.login-html .sign-up-admin:checked + .tab + .login-form .sign-up-admin-htm {
  transform: rotate(0);
}
.hr {
  height: 2px;
  margin: 60px 0 50px 0;
  background: rgba(255, 255, 255, 0.2);
}
.foot-lnk {
  text-align: center;
}
</style>

<template>
  <!-- 面包屑导航区域 -->
  <div>
    <el-breadcrumb separator=">">
      <el-breadcrumb-item :to="{ path: '/' }">首页</el-breadcrumb-item>
      <el-breadcrumb-item>
        <a href="/operationList">手术管理</a>
      </el-breadcrumb-item>
      <el-breadcrumb-item>手术列表</el-breadcrumb-item>
    </el-breadcrumb>
    <!-- 卡片视图区域 -->
    <el-card class="box-card">
      <!-- 搜索与添加区域 -->
      <el-row :gutter="20">
        <el-col :span="8">
          <el-input
            placeholder="请输入手术ID"
            v-model="queryInfo.query"
            clearable
            @clear="getOperationList"
          >
            <el-button slot="append" icon="el-icon-search" @click="getOperationList"></el-button>
          </el-input>
        </el-col>
        <el-col :span="4">
          <el-button type="primary" @click="addDialogVisible = true">添加手术</el-button>
        </el-col>
      </el-row>
      <!-- 手术列表区域 -->
      <el-table :data="tableData" style="width: 100%" border stripe>
        <el-table-column label="#" type="index"></el-table-column>
        <el-table-column prop="date" label="日期" width="180"></el-table-column>
        <el-table-column prop="op_ID" label="手术ID" width="180"></el-table-column>
        <el-table-column prop="op_name" label="手术名称" width="180"></el-table-column>
        <el-table-column prop="op_dept" label="科室名称" width="180"></el-table-column>
        <el-table-column prop="op_patient" label="病人ID" width="180"></el-table-column>
        <el-table-column prop="person_ID" label="医护人员ID" width="180"></el-table-column>
        <!-- 利用作用域插槽 -->
        <el-table-column label="操作" width="180">
          <!-- eslint-disable-next-line -->
          <template v-slot="scope">
            <!-- 修改按钮 -->
            <el-tooltip effect="dark" content="修改手术" placement="top" :enterable="false">
              <el-button
                type="primary"
                icon="el-icon-edit"
                @click="showEditDialog(scope)"
              ></el-button>
            </el-tooltip>
            <!-- 删除按钮 -->
            <el-tooltip effect="dark" content="删除手术" placement="top" :enterable="false">
              <el-button
                type="danger"
                icon="el-icon-delete"
                @click="showDeleteDialog()"
              ></el-button>
            </el-tooltip>
          </template>
        </el-table-column>
      </el-table>
    </el-card>
    <!-- 添加手术的对话框 -->
    <el-dialog title="添加手术" :visible.sync="addDialogVisible" width="50%" @close="addDialogClosed">
      <!-- 内容主体区域 -->
      <el-form
        :model="addForm"
        :rules="addFormRules"
        ref="addFormRef"
        label-width="100px"
        class="demo-ruleForm"
      >
        <el-form-item label="手术时间" required>
          <el-col :span="11">
            <el-form-item prop="date1">
              <el-date-picker
                type="date"
                placeholder="选择日期"
                v-model="addForm.date1"
                style="width: 100%;"
              ></el-date-picker>
            </el-form-item>
          </el-col>
          <el-col class="line" :span="2">-</el-col>
          <el-col :span="11">
            <el-form-item prop="date2">
              <el-time-picker placeholder="选择时间" v-model="addForm.date2" style="width: 100%;"></el-time-picker>
            </el-form-item>
          </el-col>
        </el-form-item>
        <el-form-item label="手术ID" prop="op_ID">
          <el-input v-model="addForm.op_ID"></el-input>
        </el-form-item>
        <el-form-item label="手术名称" prop="op_name">
          <el-input v-model="addForm.op_name"></el-input>
        </el-form-item>
        <el-form-item label="科室名称">
          <el-select v-model="addForm.op_dept" placeholder="请选择科室名称" style="width: 100%;">
            <el-option label="眼科" value="eye"></el-option>
            <el-option label="内科" value="medicine"></el-option>
            <el-option label="外科" value="surgery"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="病人ID" prop="op_patient">
          <el-input v-model="addForm.op_patient"></el-input>
        </el-form-item>
        <el-form-item label="医护人员ID" prop="person_ID">
          <el-input v-model="addForm.person_ID"></el-input>
        </el-form-item>
      </el-form>
      <!-- 底部区域 -->
      <span slot="footer" class="dialog-footer">
        <el-button @click="addDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="addOperation">确 定</el-button>
      </span>
    </el-dialog>

    <!-- 修改手术的对话框 -->
    <el-dialog
      title="对手术进行修改"
      :visible.sync="editDialogVisible"
      width="50%"
      @close="editDialogClosed"
    >
      <el-form
        :model="editDialogForm"
        ref="editDialogFormRef"
        label-width="100px"
      >
        <el-form-item label="手术时间" required>
          <el-col :span="11">
            <el-form-item prop="date1">
              <el-date-picker
                type="date"
                placeholder="选择日期"
                v-model="editDialogForm.date1"
                style="width: 100%;"
              ></el-date-picker>
            </el-form-item>
          </el-col>
          <el-col class="line" :span="2">-</el-col>
          <el-col :span="11">
            <el-form-item prop="date2">
              <el-time-picker
                placeholder="选择时间"
                v-model="editDialogForm.date2"
                style="width: 100%;"
              ></el-time-picker>
            </el-form-item>
          </el-col>
        </el-form-item>
        <el-form-item label="手术ID" prop="op_ID" disable="true">
          <el-input v-model="editDialogForm.op_ID"></el-input>
        </el-form-item>
        <el-form-item label="手术名称" prop="op_name">
          <el-input v-model="editDialogForm.op_name"></el-input>
        </el-form-item>
        <el-form-item label="科室名称">
          <el-select v-model="editDialogForm.op_dept" placeholder="请选择科室名称" style="width: 100%;">
            <el-option label="眼科" value="eye"></el-option>
            <el-option label="内科" value="medicine"></el-option>
            <el-option label="外科" value="surgery"></el-option>
          </el-select>
        </el-form-item>
        <el-form-item label="病人ID" prop="op_patient">
          <el-input v-model="editDialogForm.op_patient"></el-input>
        </el-form-item>
        <el-form-item label="医护人员ID" prop="person_ID">
          <el-input v-model="editDialogForm.person_ID"></el-input>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="editDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="editOperationInfo">确 定</el-button>
      </span>
    </el-dialog>

    <!-- 删除手术的对话框 -->
    <el-dialog title="删除手术" :visible.sync="deleteDialogVisible" width="50%">
      <span>
        <el-button @click="deleteDialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="showDeleteDialog">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
export default {
  data () {
    return {
      // 获取列表的参数对象
      queryInfo: {
        query: '',
        pagenum: 1,
        pagesize: 2
      },
      // 控制添加手术对话框的显示与隐藏
      addDialogVisible: false,
      // 控制修改手术对话框的显示与隐藏
      editDialogVisible: false,
      // 控制删除守住对话框的显示与隐藏
      deleteDialogVisible: false,
      // 查询到的用户信息对象
      editForm: {},
      // 添加手术的表单数据
      addForm: {
        date1: '',
        date2: '',
        op_ID: '',
        op_name: '',
        op_dept: '',
        op_patient: '',
        person_ID: ''
      },
      editDialogForm: {
        date1: '',
        date2: '',
        op_ID: '',
        op_name: '',
        op_dept: '',
        op_patient: '',
        person_ID: ''
      },
      // 添加手术的表单数据验证规则
      addFormRules: {
        op_ID: [
          {
            required: true,
            message: '请输入手术ID',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 6,
            message: '手术ID长度为 6 个字符',
            trigger: 'blur'
          }
        ],
        op_name: [
          {
            required: true,
            message: '请输入手术名称',
            trigger: 'blur'
          }
        ],
        op_dept: [
          {
            required: true,
            message: '请输入科室名称',
            trigger: 'blur'
          }
        ],
        op_patient: [
          {
            required: true,
            message: '请输入病人ID',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 6,
            message: '病人ID长度为 6 个字符',
            trigger: 'blur'
          }
        ],
        person_ID: [
          {
            required: true,
            message: '请输入医护人员ID',
            trigger: 'blur'
          },
          {
            min: 6,
            max: 6,
            message: '医护人员ID长度为 6 个字符',
            trigger: 'blur'
          }
        ]
      },

      tableData: [
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        },
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        },
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        },
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        },
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        },
        {
          date: '2016-05-02',
          op_ID: '123',
          op_name: '阑尾炎手术',
          op_dept: '外科',
          op_patient: '111',
          person_ID: ['111,', '222,', '333']
        }
      ]
    }
  },
  // 在页面创建期间，调用 getOperationList()函数，从而发起 Ajax 数据请求，get 请求会返回一个 promise 对象
  created () {
    this.getOperationList()
  },
  methods: {
    // 简化 promise 请求，使用 async
    getOperationList () {
      this.$http.get('接口地址', { params: this.queryInfo }).then((res) => {
        console.log(res)
        if (res.data !== '') {
          return this.$message.success('获取手术列表成功')
        }
      })
    },
    // 监听添加手术对话框的关闭事件
    addDialogClosed () {
      this.$refs.addFormRef.resetFields()
    },
    // 点击按钮，添加新手术
    addOperation () {
      this.$refs.addFormRef.validate((valid) => {
        if (!valid) return
        // 可以发起添加手术的网络请求
        this.$http
          .post('接口', this.addForm)
          .then((res) => {
            if (res.data !== '') {
              this.$message.success('添加手术成功')
              // 关闭添加手术表单
              this.addDialogVisible = false
              // 重新获取手术列表数据
              this.getOperationList()
            }
            return this.$message.error('添加手术失败')
          })
          .catch((res) => {
            return this.$message.error('添加手术失败')
          })
      })
    },
    showEditDialog () {
      this.$http.get('接口').then((res) => {
        if (res.data === '') {
          return this.$message.error('查询手术信息失败')
        }
      })
      this.editDialogVisible = true
    },
    // 监听修改用户对话框的关闭事件
    editDialogClosed () {
      this.$refs.editDialogFormRef.resetFields()
    },
    editOperationInfo () {
      this.$refs.editDialogFormRef.validate((valid) => {
        // 发起修改手术的网络请求
        this.$http.post('路径', this.editDialogForm
        ).then(res => {
          if (res.data !== '') {
            return this.$message.success('手术修改成功')
          }
        }).catch(res => {
          return this.$message.error('手术修改失败')
        })
      })
    },
    // 根据op_ID删除对应手术信息
    showDeleteDialog () {
      // 弹窗：询问是否删除
      const confirmResult = this.$confirm('此操作将永久删除该条手术信息, 是否继续?', '提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning'
      }).catch(err => err)
      // 如果用户确认删除，则返回字符串 confirm
      // 如果用户取消删除，则返回字符串 cancel
      // console.log(confirmResult)
      if (confirmResult !== confirm) {
        return this.$message.info('已取消删除')
      }

      this.$http.post('地址' + '数据')
    }
  }
}
</script>

<style>
.text {
  font-size: 14px;
}

.item {
  margin-bottom: 18px;
}

.clearfix:before,
.clearfix:after {
  display: table;
  content: "";
}
.clearfix:after {
  clear: both;
}

.box-card {
  width: 1351px;
  height: 800px;
}
.el-table {
  margin-top: 15px;
}
</style>

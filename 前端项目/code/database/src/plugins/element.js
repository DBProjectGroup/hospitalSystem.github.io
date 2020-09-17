import Vue from 'vue'
import Element, { Message, MessageBox } from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'

Vue.use(Element)
// 把message组建挂载到vue的原型组件上，让每一个组件能通过this访问到$message，然后$message进行弹窗提示
Vue.prototype.$message = Message
Vue.prototype.$confirm = MessageBox.confirm

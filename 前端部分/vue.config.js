module.exports = {
  publicPath: process.env.NODE_ENV === 'production' ? '/e-sun-manage/' : '/',
  devServer: {
    port: 7984,
    open: true,
    // 设置代理，使客户端通过服务器的方式与服务器通信，解决跨域问题
    // 在本地会创建一个虚拟服务端，然后发送请求的数据，
    // 并同时接收请求的数据，这样服务端和服务端进行数据的交互就不会有跨域问题
    // proxy: {}
    proxy: {
      '/api': {
        target: 'https://localhost:44347', //目标路径，别忘了加http和端口号
        changeOrigin: true,
        pathRewrite: {
          '^/api': ''
        }
      }
    }
  },
  // build:{

  // }
  //mock的配置
  // proxyTable: {
  //   '/api': {
  //     target: 'http://localhost:8080', // 本地ip
  //     pathRewrite: {
  //       '^/api': '/static/mock'  // mock数据的文件路径
  //     }
  //   }
  // },
  // proxyTable: {  // 配置后台代理

  //     '/api': {
  //     target: 'http://localhost:8080', //本地测试环境请求后台接口的域名和端口号，目标路径，别忘了加http和端口号
  //     changeOrigin: true
  //     pathRewrite: {
  //     '^/api': '' //这里理解成用‘/api’代替target里面的地址，后面组件中我们掉接口时直接用api代替 比如我要调用'http://40.00.100.100:3002/user/add'，直接写‘/api/user/add’即可
  //     }
  //     },
  //       }
  // 配置多个跨域接口
  // proxyTable: {
  //   '/api' : {
  //      target: 'https://touch.dujia.qunar.com',//目标路径，别忘了加http和端口号
  //      changeOrigin: true,
  //      pathRewrite: {
  //        '^/api': ''
  //      }
  //   },
  //   '/zt' : {
  //      target: 'https://zt.dujia.qunar.com',
  //      changeOrigin: true,
  //      pathRewrite: {
  //        '^/zt': ''
  //      }
  //   }
  //  },
  // css相关的配置
  css: {
    loaderOptions: {
      sass: {
        // 这里data换成 prependData  并且重启vue项目即可
        // 设置相对路径
        prependData: `@import "@/assets/scss/_variable.scss";`
      }
    }
  }
}

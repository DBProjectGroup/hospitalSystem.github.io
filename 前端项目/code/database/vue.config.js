module.exports = {
  publicPath: process.env.NODE_ENV === 'production' ? '/e-sun-manage/' : '/',
  devServer: {
    port: 8888,
    open: true,
    // 设置代理，使客户端通过服务器的方式与服务器通信，解决跨域问题
    // 在本地会创建一个虚拟服务端，然后发送请求的数据，
    // 并同时接收请求的数据，这样服务端和服务端进行数据的交互就不会有跨域问题
    // proxy: {}
    proxy: {
      '/api': {
        target: 'https://localhost:44347', // 目标路径，别忘了加http和端口号
        changeOrigin: true,
        pathRewrite: {
          '^/api': ''
        }
      }
    }
  }
}

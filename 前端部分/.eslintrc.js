module.exports = {
  root: true,
  env: {
    node: true
  },
  extends: ['plugin:vue/essential', 'eslint:recommended', '@vue/prettier'],
  parserOptions: {
    parser: 'babel-eslint'
  },
  rules: {
    'no-console': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'no-debugger': process.env.NODE_ENV === 'production' ? 'warn' : 'off',
    'prettier/prettier': [
      'error',
      {
        //!!!!这里设置后，通过package.json第9行的lint脚本，一次性让整个项目格式化
        //让项目用分号；结尾的规则变为不用分号结尾，当用分号结尾时，会报错
        semi: false,
        //用单引号代替双引号
        singleQuote: true,
        //换行，html里的换行
        printWidth: 80
      }
    ]
  }
}

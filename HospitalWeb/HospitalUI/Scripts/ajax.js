function ajax(options){
    var defaults={
        type:'get',
        url:'',
        data:{},
        header:{
            'Content-Type':'application/x-www-form-urlencoded'
        },
        success:function(){},
        error:function(){}
    }
    Object.assign(defaults,options);
    var xhr=new XMLHttpRequest();
    var params= '';
    for(var attr in defaults.data){
        params+=attr+'='+defaults.data[attr]+'&';
    }
    params=params.substr(0,params.length-1);
    //console.log(params);
    if(defaults.type=='get'){
        defaults.url=defaults.url+'?'+params;
    }
    xhr.open(defaults.type,defaults.url);
    if(defaults.type=='post'){
        var contentType=defaults.header['Content-Type'];
        xhr.setRequestHeader('Content-Type',contentType);
        if(contentType=='application/json'){
            xhr.send(JSON.stringify(defaults.data));
        }
        else{
        xhr.send(params);}
    }
    else{
    xhr.send();}
    xhr.addEventListener('load',function(){
        var contentType=xhr.getResponseHeader('Content-Type');//响应头中的数据
        var responseText =xhr.responseText;
        if(contentType.includes('application/json')){
             responseText=JSON.parse(responseText);
        }
        //console.log(xhr.responseText);
        //当http状态码为200，请求成功
        if(xhr.status==200){
        defaults.success(responseText,xhr);
    }
        else{
        defaults.error(responseText,xhr);
        }
    })
}
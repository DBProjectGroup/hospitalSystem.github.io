
    function setCookie(name,value,iDay){
        var oDate =new Date();
        oDate.setDate(oDate.getDate()+iDay);
      document.cookie=name+'='+value+';expires='+oDate;
    }
    function getCookie(name){
        var arr =document.cookie.split("; ");
        for(var i=0;i<arr.length;i++){
            var arr2=arr[i].split('=');
            if(arr2[0]==name){
                return arr2[1];
            }
        }
        return '';
    }
    function removeCookie(name){
        setCookie(name,1,-1);
    }
    function cookieToJson() {
        let cookieArr = document.cookie.split(";");
        let obj = {} 
        cookieArr.forEach((i) => {
            let arr = i.split("=");
            obj[arr[0]] =arr[1];
        });
        return obj
      }

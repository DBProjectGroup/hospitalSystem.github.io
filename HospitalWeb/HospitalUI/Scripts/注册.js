
        window.onload=function(){
            var lis=document.querySelectorAll('#main .back .table li');
            for(var i in lis){
                lis[i].onclick=function(){
                    for(var j=0;j<lis.length;j++){
                        lis[j].lastElementChild.style.display='none';
                    }
                  this.lastElementChild.style.display='block' ; 
                }
            }
        }

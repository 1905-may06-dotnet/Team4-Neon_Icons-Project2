window.onload = function(){
    var url = 'http://neonicons.azurewebsites.net/api/values/getweather/78754';
    var weather = document.getElementById("weather");
    var img = document.getElementById("img-container");

    //1. Create object of XMLHttpRequest
    if(XMLHttpRequest)
        var request = new XMLHttpRequest(); 
    else
        var request = new ActiveXObject();

//2. Handle the ReadyStateChange Event for responses
    request.onreadystatechange = function() {

        console.log(`${request.readyState}${request.status}${request.statusText}`);

        if(request.readyState === 4 && request.status == 200)
        {
        var result = request.response;
        var jsonResult = JSON.parse(result);

        var type = jsonResult.type;
        var div = document.createElement("img-container");
        debugger;
        if (type === "Clear"){
            div.innerHTML="<img src=/imgs/sunny.png>";
            img.appendChild(div);
        }
        else if(type === "Sand" 
        || type === "Ash" 
        || type === "Dust" 
        || type === "Haze")
        {
            div.innerHTML="<img src=/imgs/partly-sunny.png>";
            img.appendChild(div);
        }
        else if(type === "Drizzle" 
        || type === "Rain" 
        || type === "Mist" 
        || type === "Snow")
        {
            div.innerHTML="<img src=/imgs/rainy.png>";
            img.appendChild(div);
        }
        else if (type === "Clouds" 
        || type === "Smoke" 
        || type === "Fog")
        {
            div.innerHTML="<img src=/imgs/cloudy.png>";
            img.appendChild(div);
        }
        else if (type === "Thunderstorm" 
        || type === "Squall" 
        || type === "Tornado")
        {
            div.innerHTML="<img src=/imgs/thunderstorm.png>";
            img.appendChild(div);
        }

        console.log(typeof(result));
        var h3 = document.createElement("h3");
        h3.innerHTML=result;
        weather.appendChild(h3);
        };
    };

//3. Open Request
request.open('GET', url, true);

//4. Send Request
request.send();

};
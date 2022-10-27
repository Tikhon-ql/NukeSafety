


function init() {
    alert("anime");
    let map = new ymaps.Map('map-test', {
        center: [55.74836824450157, 37.62782219845586],
        zoom: 15
    });
}

ymaps.ready(init);


const options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 0
}



function success(pos)
{
    
}
function error(err) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
}


navigator.geolocation.getCurrentPosition(success, error, options);
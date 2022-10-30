let coords;
let map;

let longitude = document.getElementById("longitude");
let latitude = document.getElementById("latitude");
let buttonDetonate = document.getElementById("buttonDetonate");
//------------------
var options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 0
};

navigator.geolocation.getCurrentPosition(success, error, options);

function success(event) {
    coords = [event.coords.latitude, event.coords.longitude];
    console.dir(coords);
}
function error(event) {
    console.warn(`ERROR(${err.code}): ${err.message}`);
}

//------------------

ymaps.ready(init);

function init() {

    longitude.textContent = coords[0];
    latitude.textContent = coords[1];

    var myMap = new YandexMap(coords);

    console.dir(coords);
  

    buttonDetonate.addEventListener('click', function (e) {
        e.preventDefault();
        //alert("anime");

        //console.dir(map.geoObjects);
        myMap.detonate();
    })
}
//----------------------------


class YandexMap
{
    constructor(coords){
        this.map = new ymaps.Map('map-test', {
            center: coords,
            zoom: 15
        });

        this.map.events.add('click', function(e){
            //document.getElementById("longitude").textContent = e.get('coords')[0];
            //document.getElementById("latitude").textContent = e.get('coords')[1];
            longitude.textContent = e.get('coords')[0];
            latitude.textContent = e.get('coords')[1];
        })
    }
    detonate() {
        //console.dir(map);
        console.dir(this);
        var blasteYield = document.forms[0][0].value;
        var myCircle1 = new ymaps.Circle([
            [longitude.textContent, latitude.textContent],
            blasteYield
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: false,
            fillColor: "#DB709377",
            strokeColor: "#990066",
            strokeOpacity: 0.8,
            strokeWidth: 5
        });
        var myCircle2 = new ymaps.Circle([

            [longitude.textContent, latitude.textContent],
            Number(blasteYield) + Number(500)
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: false,
            fillColor: "#235789",
            fillOpacity: 0.5,
            strokeColor: "#ED1C24",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        var myCircle3 = new ymaps.Circle([

            [longitude.textContent, latitude.textContent],
            Number(blasteYield) + Number(1500)
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: false,
            fillColor: "#8332AC",
            fillOpacity: 0.5,
            strokeColor: "#462749",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        var myCircle4 = new ymaps.Circle([

            [longitude.textContent, latitude.textContent],
            Number(blasteYield) + Number(2500)
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: false,
            fillColor: "#BAD1CD",
            fillOpacity: 0.5,
            strokeColor: "#F2D1C9",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        var myCircle5 = new ymaps.Circle([

            [longitude.textContent, latitude.textContent],
            Number(blasteYield) + Number(4000)
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: false,
            fillColor: "#51E5FF",
            fillOpacity: 0.5,
            strokeColor: "#EC368D",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        this.map.geoObjects.add(myCircle1);
        this.map.geoObjects.add(myCircle2);
        this.map.geoObjects.add(myCircle3);
        this.map.geoObjects.add(myCircle4);
        this.map.geoObjects.add(myCircle5);
    }
}
let coords;
let map;

let longitude = document.getElementById("longitude");
let latitude = document.getElementById("latitude");
let buttonDetonate = document.getElementById("buttonDetonate");
let buttonSwitch = document.getElementById("switchButton");
//let setPersonButton = document.getElementById("setPerson");
let explosionType = document.getElementsByName("type")[0];

/*let availableToSetPersonPosition = false;*/
let isConstructFormVisible = false;
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

    //longitude.textContent = coords[0];
    //latitude.textContent = coords[1];

    var myMap = new YandexMap(coords);

    console.dir(coords);


    buttonDetonate.addEventListener('click', function (e) {
        e.preventDefault();
        myMap.detonate();
    })
    buttonSwitch.addEventListener('click', function (e) {
        e.preventDefault();
        if (!isConstructFormVisible) {
            document.getElementById("constructBomb").style.visibility = "visible";
            document.getElementById("selectBomb").style.visibility = "hidden";
        }
        else {
            document.getElementById("selectBomb").style.visibility = "visible";
            document.getElementById("constructBomb").style.visibility = "hidden";
        }
        isConstructFormVisible = !isConstructFormVisible;
    })
    //setPersonButton.addEventListener('click', function (event) {
    //    if (!availableToSetPersonPosition) {
    //        availableToSetPersonPosition = true;
    //        setPersonButton.textContent = "Remove person placemark";
    //    }
    //    else {
    //        availableToSetPersonPosition = false;
    //        myMap.removePlacemark();
    //        setPersonButton.textContent = "Set person placemark";
    //    }
    //});
}
//----------------------------


class YandexMap {
    constructor(coords) {

      
        this.placemark = new ymaps.Placemark(coords,
            {
                hintContent: 'You',
                iconCaption: 'You'
            },
            {
                iconLayout: 'default#image',
                iconImageHref: "img/person.png",
                iconImageSize: [40, 40],
                iconImageOffset: [-19, -40],
                draggable: true
            });
        this.map = new ymaps.Map('map-test', {
            center: coords,
            zoom: 10
        });

        this.bombPlacemark = new ymaps.Placemark(coords, null, {
            iconLayout: 'default#image',
            iconImageHref: 'img/location-mark.png',
            iconImageSize: [40, 40],
            iconImageOffset: [-19, -40],
            draggable: true
        });

        this.myCircle1 = new ymaps.Circle([
            this.bombPlacemark.geometry.getCoordinates(),
            blasteYield
        ], null, {
            draggable: false,
            fillColor: "#DB709377",
            strokeColor: "#990066",
            strokeOpacity: 0.8,
            strokeWidth: 5
        });
        this.myCircle2 = new ymaps.Circle([

            this.bombPlacemark.geometry.getCoordinates(),
            Number(blasteYield) + Number(500)
        ], null, {
            draggable: false,
            fillColor: "#235789",
            fillOpacity: 0.5,
            strokeColor: "#ED1C24",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        this.myCircle3 = new ymaps.Circle([

            this.bombPlacemark.geometry.getCoordinates(),
            Number(blasteYield) + Number(1500)
        ], null, {
            draggable: false,
            fillColor: "#8332AC",
            fillOpacity: 0.5,
            strokeColor: "#462749",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        this.myCircle4 = new ymaps.Circle([

            this.bombPlacemark.geometry.getCoordinates(),
            Number(blasteYield) + Number(2500)
        ], null, {
            draggable: false,
            fillColor: "#BAD1CD",
            fillOpacity: 0.5,
            strokeColor: "#F2D1C9",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        this.myCircle5 = new ymaps.Circle([

            this.bombPlacemark.geometry.getCoordinates(),
            Number(blasteYield) + Number(4000)
        ], null, {
            draggable: false,
            fillColor: "#51E5FF",
            fillOpacity: 0.5,
            strokeColor: "#EC368D",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });


        this.map.geoObjects.add(this.bombPlacemark);
        this.map.geoObjects.add(this.placemark);

        this.map.events.add('click', (e) => {
            //document.getElementById("longitude").textContent = e.get('coords')[0];
            //document.getElementById("latitude").textContent = e.get('coords')[1];
            //longitude.textContent = e.get('coords')[0];
            //latitude.textContent = e.get('coords')[1];
            //this.setPlacemark(e.get('coords'));
            //if (availableToSetPersonPosition) {
            //    this.setPlacemark(e.get('coords'));
            //}
            //else
            //    this.removePlacemark();
        })
    }
    detonate() {
        //console.dir(map);
        let radius;
        let blasteYield;

        if (!isConstructFormVisible) {
            let bombId = document.getElementById("bombId").value;
            $.ajax(
                {
                    "url": "Home/GetBombRadiuses",
                    "data": { "bombId": bombId, "type": explosionType.value },
                    "dataType": "json",
                    "success": function (data) {
                        blasteYield = data;
                        console.log(blasteYield);
                    }
                });
        }
        else {
            blasteYield = document.forms[0][0].value;
            $.post("Home/CreateExplosion", { "blastYeild": blasteYield, "type": explosionType.value });
        }
        console.log(blasteYield);

        this.map.geoObjects.remove(this.myCircle1);
        this.map.geoObjects.remove(this.myCircle2);
        this.map.geoObjects.remove(this.myCircle3);
        this.map.geoObjects.remove(this.myCircle4);
        this.map.geoObjects.remove(this.myCircle5);

        this.myCircle1.geometry.setCoordinates(this.bombPlacemark.geometry.getCoordinates());
        this.myCircle2.geometry.setCoordinates(this.bombPlacemark.geometry.getCoordinates());
        this.myCircle3.geometry.setCoordinates(this.bombPlacemark.geometry.getCoordinates());
        this.myCircle4.geometry.setCoordinates(this.bombPlacemark.geometry.getCoordinates());
        this.myCircle5.geometry.setCoordinates(this.bombPlacemark.geometry.getCoordinates());

        this.myCircle1.geometry.setRadius(blasteYield);
        this.myCircle2.geometry.setRadius(Number(blasteYield) + 500);
        this.myCircle3.geometry.setRadius(Number(blasteYield) + 1500);
        this.myCircle4.geometry.setRadius(Number(blasteYield) + 2500);
        this.myCircle5.geometry.setRadius(Number(blasteYield) + 4000);

        this.map.geoObjects.add(this.myCircle1);
        this.map.geoObjects.add(this.myCircle2);
        this.map.geoObjects.add(this.myCircle3);
        this.map.geoObjects.add(this.myCircle4);
        this.map.geoObjects.add(this.myCircle5);
    }
    setPlacemark(coords) {
        console.log(coords);
        this.map.geoObjects.remove(this.placemark);
        this.placemark.geometry.setCoordinates(coords);
        this.map.geoObjects.add(this.placemark);
    }
    removePlacemark() {
        this.map.geoObjects.remove(this.placemark);
    }
}

document.getElementById("bombId").addEventListener('change', function (event) {
    document.getElementById("currentBombId").value = event.target.value;
});
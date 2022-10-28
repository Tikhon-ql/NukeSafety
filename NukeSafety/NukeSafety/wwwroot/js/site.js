
ymaps.ready(init);

let map;

function init() {
    map = new ymaps.Map('map-test', {
        center: [55.76, 37.60],
        zoom: 15
    });

    map.events.add('click', function (e) {
        console.log(e.get('coords'));
        var myCircle = new ymaps.Circle([

           e.get('coords'),
            10000
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: true,
            fillColor: "#DB709377",
            strokeColor: "#990066",
            strokeOpacity: 0.8,
            strokeWidth: 5
        });
        var myCircle2 = new ymaps.Circle([

            e.get('coords'),
            20000
        ], {
            balloonContent: "Радиус круга - 10 км",
            hintContent: "Подвинь меня"
        }, {
            draggable: true,
            fillColor: "#235789",
            fillOpacity: 0.5,
            strokeColor: "#ED1C24",
            strokeOpacity: 0.8,
            strokeWidth: 10
        });
        map.geoObjects.add(myCircle);
        map.geoObjects.add(myCircle2);
    })
}




//const options = {
//    enableHighAccuracy: true,
//    timeout: 5000,
//    maximumAge: 0
//}



//function success(pos) {

//}
//function error(err) {
//    console.warn(`ERROR(${err.code}): ${err.message}`);
//}


//navigator.geolocation.getCurrentPosition(success, error, options);
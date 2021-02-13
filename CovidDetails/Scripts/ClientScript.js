var City = []
//fetch City from database
function LoadCity(element) {
    if (cities.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/Home/getHospitalCities',
            success: function (data) {
                cities = data;
                //render City
                renderCity(element);
            }
        })
    }
    else {
        //render City to the element
        renderCity(element);
    }
}

function renderCity(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(City, function (i, val) {
        $ele.append($('<option/>').val(val.CityId).text(val.CityName));
    })
}

//fetch Hospitals  DropDown
function LoadHospitals(cityDd) {
    $.ajax({
        type: "GET",
        url: '/Home/getHospitalnames',
        data: { 'cityId': $(cityDd).val() },
        success: function (data) {
            //render products to appropriate dropdown
            renderHospitals($(cityDd).parents('.mycontainer').find('select.Hospitals'), data);
        },
        error: function (error) {
            console.log(error);
        }
    })
}

function renderHospitals(element, data) {
    //render product
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.HospitalId).text(val.HospitalName));
    })
}




LoadCity($('#HospitalCities'));
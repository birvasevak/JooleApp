
$(document).ready(()=>{
    var selectedIDs = [];
    var catId;
    var subCatID;


    $('#CategoryId').prop('selectedIndex', 0);
    console.log("Selected IDs" + selectedIDs);

    $(".sliderInside").on('input change', (e) => {
        $(".sliderInside").each((pos, obj) => {
            let name = "#" + obj.id
            if (name != "#") {
                let tempMin = "#minVal_" + obj.id;
                let tempMax = "#maxVal_" + obj.id;
                let updateID = "#valueUpdate_" + obj.id;
                let percentage = parseFloat($(name).val());
                tempMin = parseFloat($(tempMin).text().split(' ').join(''));
                tempMax = parseFloat($(tempMax).text().split(' ').join(''));
                let tempValue = tempMin + percentage * (tempMax - tempMin) / 100;

                $(updateID).text(tempValue);
            }
        });
    });
    RefreshSomeEventListener();

    $(".searchButton").on('click', (e) => {
        var sliderValue = {
            "data": {}, "data2": {}
        };

        console.log("Selected IDs after search " + selectedIDs);

        $(".sliderInside").each((pos, obj) => {
            let name = "#" + obj.id

            if (name != "#") {
                let tempMin = "#minVal_" + obj.id;
                let tempMax = "#maxVal_" + obj.id;
                
                let percentage = parseFloat($(name).val());
                tempMin = parseFloat($(tempMin).text().split(' ').join(''));
                tempMax = parseFloat($(tempMax).text().split(' ').join(''));
                let tempValue = tempMin + percentage * (tempMax - tempMin) / 100;
                
                
                sliderValue["data"][(name.split("#")[1]).split("_").join(" ")] = tempValue;
            }
        });

        sliderValue["data2"]["id"] = $("#subCategoryID").val()

        $.ajax({
            type: "POST",
            url: "updateProductsQuery/ProductSummary",
            data: sliderValue,
            success: (result) => {
                selectedIDs = [];
                $(".productsDisplay").html(result);
                RefreshSomeEventListener();
            },
            error: (e) => {
                console.log(e);
            }

        })
    });

    //$("#CategoryId").addClass("dropdownCat");
    $("#CategoryId option").addClass("white");
    
    $("#CategoryId").change(function () {
        catId = $(this).val();
        $.ajax({
            type: "POST",
            url: "/Search/GetSubCategoryList?categoryId=" + catId,
            contentType: "html",
            success: function (response) {
                console.log("Run")
                $("#SubCategoryID").empty();
                $("#SubCategoryID").append(response);
            },
            error: function (err) {
                console.log(err);
            }
        });
    });

    $("#SubCategoryID").change(function () {
        subCatID = $(this).val();
    });

    $("#btnSearch").on("click", () => {
        $("#CategoryId").val("Category").change();
    });


    function RefreshSomeEventListener() {
        // Remove handler from existing elements
        $(".itemCheck").off();

        $(".itemCheck").on("click", (e) => {
            var productID = (e.target.id).split("_")[1];

            var itemID = "#" + e.target.id;
            if ($(itemID).prop("checked") == true) {
                selectedIDs.push(productID);
                
            } else {
                var temp = selectedIDs.indexOf(productID);
                selectedIDs.splice(temp, 1);
            }
            console.log("Added" + selectedIDs);
            
        });
    }

    $(function () {
        counter = 0;
        $(".itemCheck").click(function () {

            if (this.checked) {
                counter++;
                console.log("counter: " + counter);
                if (counter == 2 || counter == 3) {
                    $("#btnCompare").removeAttr("disabled");
                }
            } else {
                counter--;
                if (counter != 2 || counter != 3) {
                    $("#btnCompare").attr("disabled", "disabled");
                }
            }
        });


       /* $("#btnCompare").click(function () {
            $.ajax({
                url: '.././Search/compare',
                dataType: 'json',
                method: 'POST',
                data: {
                    id1: 4,
                    id2: 5
                }
            });
        });*/
    });

});
function DisplayView_Reports(arg) {
    ClearHighlight();
    var btnName = "btn" + arg;

    document.getElementById(btnName).setAttribute('class', 'list-group-item active');

    if (arg == "SalesReport" || arg == "InventoryReport" ) {

        $.ajax({
            type: "POST",
            url: "/Report/ReportPartial",

            data: JSON.stringify({ 'fcn': arg }),
            contentType: "application/json; charset=utf-8",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {
                var reportObject = $('#reportViewer').data('ejReportViewer');
                if (reportObject) {
                    reportObject.destroy();
                }
                $("#partial").html(response);
                ej.widget.init($("#partial"));
            }
        });
    }
    else if (arg == "CategoryDetailReport") {
        $.ajax({
            type: "GET",

            url: "/Report/CategoryDetail",
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#partial').html(response);

                ej.widget.init($("#partial"));
            }
        });

    }

    else if (arg == "CategorySummaryReport") {
        $.ajax({
            type: "GET",

            url: "/Report/CategorySummary",
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#partial').html(response);

                ej.widget.init($("#partial"));
            }
        });

    }
    else if (arg == "CashOutSummaryReport") {
        $.ajax({
            type: "GET",

            url: "/Report/CashOutSummary",
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#partial').html(response);

                ej.widget.init($("#partial"));
            }
        });

    }
    else if (arg == "CashOutDetailReport") {
        $.ajax({
            type: "GET",

            url: "/Report/CashOutDetail",
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#partial').html(response);

                ej.widget.init($("#partial"));
            }
        });

    }
    else if (arg =="ServiceSalesMonthly")
    {
        $.ajax({
            type: "GET",

            url: "/Report/ServiceSalesMonthly",
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#partial').html(response);

                ej.widget.init($("#partial"));
            }
        });
        
    }
    else if (arg == "SalesComparison") {
        $.ajax({
            type: "GET",

            url: "/Report/SalesComparison",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {
                $('#partial').html(response);
                ej.widget.init($("#partial"));
            }
        });

    }
    else if (arg == "CurrentMonthServiceSales") {
        $.ajax({
            type: "GET",

            url: "/Report/CurrentMonthServiceSales",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {
                $('#partial').html(response);
                ej.widget.init($("#partial"));
            }
        });

    } 
    else if (arg == "ServiceSalesOvertime") {
        $.ajax({
            type: "GET",

            url: "/Report/ServiceSalesOvertime",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {
                $('#partial').html(response);
                ej.widget.init($("#partial"));
            }
        });

    }
}

function viewCategorySummary() {


    var obj = $('#fromdate').data('ejDatePicker');
    var strfromdate = obj.getValue();

    var obj = $('#todate').data('ejDatePicker');
    var strtodate = obj.getValue();

    $.ajax({
        type: "POST",
        url: "/Report/CategorySummaryReport",

        data: JSON.stringify({ 'fromDate': strfromdate, 'toDate': strtodate }),
        contentType: "application/json; charset=utf-8",
        error: function (xhr, status, error) {

            alert(error);
        },
        success: function (response) {
            var reportObject = $('#reportViewer').data('ejReportViewer');
            if (reportObject) {
                reportObject.destroy();
            }
            $('#container').html(response);

            ej.widget.init($("#container"));
        }
    });


}

function viewCategoryDetail() {
  

    var obj = $('#fromdate').data('ejDatePicker');
    var strfromdate = obj.getValue();

    var obj = $('#todate').data('ejDatePicker');
    var strtodate = obj.getValue();

    $.ajax({
        type: "POST",
        url: "/Report/CategoryDetailReport",

        data: JSON.stringify({ 'fromDate': strfromdate , 'toDate' :strtodate }),
        contentType: "application/json; charset=utf-8",
        error: function (xhr, status, error) {
  
            alert(error);
        },
        success: function (response) {
            var reportObject = $('#reportViewer').data('ejReportViewer');
            if (reportObject) {
                reportObject.destroy();
            }
            //$("#partial").html(response);
            //ej.widget.init($("#partial"));

            $('#container').html(response);

            ej.widget.init($("#container"));
        }
    });


}


function viewCashOutSummary() {


    var obj = $('#fromdate').data('ejDatePicker');
    var strfromdate = obj.getValue();

    var obj = $('#todate').data('ejDatePicker');
    var strtodate = obj.getValue();

    $.ajax({
        type: "POST",
        url: "/Report/CashOutSummaryReport",

        data: JSON.stringify({ 'fromDate': strfromdate, 'toDate': strtodate }),
        contentType: "application/json; charset=utf-8",
        error: function (xhr, status, error) {

            alert(error);
        },
        success: function (response) {
            var reportObject = $('#reportViewer').data('ejReportViewer');
            if (reportObject) {
                reportObject.destroy();
            }
            //$("#partial").html(response);
            //ej.widget.init($("#partial"));

            $('#container').html(response);

            ej.widget.init($("#container"));
        }
    });


}

function viewCashOutDetail() {


    var obj = $('#fromdate').data('ejDatePicker');
    var strfromdate = obj.getValue();

    var obj = $('#todate').data('ejDatePicker');
    var strtodate = obj.getValue();

    $.ajax({
        type: "POST",
        url: "/Report/CashOutDetailReport",

        data: JSON.stringify({ 'fromDate': strfromdate, 'toDate': strtodate }),
        contentType: "application/json; charset=utf-8",
        error: function (xhr, status, error) {

            alert(error);
        },
        success: function (response) {
            var reportObject = $('#reportViewer').data('ejReportViewer');
            if (reportObject) {
                reportObject.destroy();
            }
            //$("#partial").html(response);
            //ej.widget.init($("#partial"));

            $('#container').html(response);

            ej.widget.init($("#container"));
        }
    });


}

function viewServiceSalesOvertime() {
    var obj = $('#fromdate').data('ejDatePicker');
    var strfromdate = obj.getValue();

    var obj = $('#todate').data('ejDatePicker');
    var strtodate = obj.getValue();
   
        $.ajax({
            type: "GET",

            url: "/Report/_ServiceSalesOvertime?fromdate=" + strfromdate + "&todate=" + strtodate,

            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#container').html(response);

                ej.widget.init($("#container"));
            }
        })


    }

function ClearHighlight()
{
    document.getElementById("btnSalesReport").setAttribute('class', 'list-group-item');
    document.getElementById("btnInventoryReport").setAttribute('class', 'list-group-item');
    document.getElementById("btnCashOutSummaryReport").setAttribute('class', 'list-group-item');
    document.getElementById("btnCashOutDetailReport").setAttribute('class', 'list-group-item');
    document.getElementById("btnServiceSalesMonthly").setAttribute('class', 'list-group-item');
    document.getElementById("btnServiceSalesOvertime").setAttribute('class', 'list-group-item');
    document.getElementById("btnCurrentMonthServiceSales").setAttribute('class', 'list-group-item');
    document.getElementById("btnSalesComparison").setAttribute('class', 'list-group-item');
    document.getElementById("btnCategoryDetailReport").setAttribute('class', 'list-group-item');
    document.getElementById("btnCategorySummaryReport").setAttribute('class', 'list-group-item');



}
function viewChartServiceSalesMonthly() {
 
    alert('test')
    var obj = $('#ddlMonth').data('ejDropDownList');
    var strmonth = obj.getValue();


    var obj = $('#ddlYear').data('ejDropDownList');
    var stryear = obj.getValue();
   
    if (stryear == "" || strmonth == "")
    { alert("Please select inputs") }
    else
    {

 alert(stryear + " " + strmonth)
        $.ajax({
            type: "GET",

            url: "/Report/_SalesMonthlyChart?month=" + strmonth + "&year=" + stryear,
            contentType: "application/json",
            error: function (xhr, status, error) {
                alert(error);
            },
            success: function (response) {

                $('#container').html(response);

                ej.widget.init($("#container"));
            }
        })
    }
 }

function HideAll() {
    document.getElementById("LoadProduct").style.display = "None";
    document.getElementById("LoadService").style.display = "None";
    document.getElementById("LoadCustomer").style.display = "None";
    document.getElementById("LoadStaff").style.display = "None";
    document.getElementById("LoadSupplier").style.display = "None";
    document.getElementById("LoadStore").style.display = "None";
    document.getElementById("LoadCompany").style.display = "None";


    document.getElementById("btnProduct").setAttribute('class', 'list-group-item');
    document.getElementById("btnService").setAttribute('class', 'list-group-item');
    document.getElementById("btnCustomer").setAttribute('class', 'list-group-item');
    document.getElementById("btnStaff").setAttribute('class', 'list-group-item');
    document.getElementById("btnSupplier").setAttribute('class', 'list-group-item');
    document.getElementById("btnStore").setAttribute('class', 'list-group-item');
    document.getElementById("btnCompany").setAttribute('class', 'list-group-item');
}

function DisplayView(args) {
    HideAll()
    var btnName = args.replace("Load", "btn"); 
    var Header = args.replace("Load", "");
    document.getElementById(btnName).setAttribute('class', 'list-group-item active');
    document.getElementById(args).style.display = "inline";

    //document.getElementById("PanelTitle").val = "Test";
    document.getElementById("PanelTitle").innerText = Header;
    //document.getElementById("PanelTitle").text = "Test";
    //$('#PanelTitle').value = "Reposne";  
  }

function HighlightRow() {
    $(this).addClass('active').siblings().removeClass('active');
}
//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Product-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------



function onActionComplete_Product(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Product");

        var categoryData = this.getColumnByField("CategoryID").dataSource;
        var supplierData = this.getColumnByField("SupplierID").dataSource;
        var categoryDropDownListObj = $('#CategoryID').ejDropDownList({
            dataSource: categoryData,
            fields: { id: "CategoryID", value: "CategoryID", text: "Name" },
            width: "200px",
            height: "28px"
        }).data("ejDropDownList");

        $("#SupplierID").ejDropDownList({
            value: $("#SupplierID").val(),
            dataSource: supplierData,
            fields: { id: "SupplierID", value: "SupplierID", text: "Name" },
            //selectedIndex: 0,
            width: "200px",
            height: "28px"
        }).data("ejDropDownList");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Product");
            categoryDropDownListObj.selectItemByValue(args.rowData.CategoryID);// SelectedCategory[0].CategoryID);
            $("#SupplierID").ejDropDownList("selectItemByValue", args.rowData.SupplierID);
        }

        $("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "300px", height: "28px", decimalPlaces: 2 });
        $("#WholesalePrice").ejCurrencyTextbox({ value: $("#WholesalePrice").val(), width: "300px", height: "28px", decimalPlaces: 2 });
        $("#UnitsInStock").ejNumericTextbox({ value: $("#UnitsInStock").val(), width: "300px", height: "28px" });
        $("#UnitsOnOrder").ejNumericTextbox({ value: $("#UnitsOnOrder").val(), width: "300px", height: "28px" });
        $("#MinimumStockLevel").ejNumericTextbox({ value: $("#MinimumStockLevel").val(), width: "300px", height: "28px" });
        $("#Name").ejMaskEdit({ value: $("#Name").val(), width: "300px", height: "28px" });
        $("#Commission").ejMaskEdit({ value: $("#Commission").val(), width: "300px", height: "28px" });
        $("#BarCode").ejMaskEdit({ value: $("#BarCode").val(), width: "300px", height: "28px" });

    }
}

function add_Product() {
    var gridObj = $("#ProductGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Product(args) {
    var gridObj = $("#ProductGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Product() {
    var gridObj = $("#ProductGrid").data("ejGrid");
    gridObj.deleteRecord("ProductID", gridObj.getSelectedRecords()[0]);
}

function endEdit_Product(args) {
    $.ajax({
        url: "/Products/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#ProductGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Product(args) {
    $.ajax({
        url: "/Products/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#ProductGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Product(args) {
    $.ajax({
        url: "/Products/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.ProductID }),
        success: function (value) {
            $("#ProductGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}



//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Service-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------

var SelectedProductID;
var selectedProductRow;

function onRowSelected_Service(args) {
    //$("#txtServiceName").html(this.getSelectedRecords()[0].Name);
    //$("#txtServiceDescription").html(this.getSelectedRecords()[0].Description);
    //var ColCategory = this.getColumnByField("CategoryID");
    //var SelectedCategory = ej.DataManager(ColCategory.dataSource).executeLocal(ej.Query().where("CategoryID", "equal", this.getSelectedRecords()[0].CategoryID, true));

    //$("#txtServiceCategory").html(SelectedCategory[0].Name);

    //$("#txtServicePrice").html(this.getSelectedRecords()[0].Price);

    //$("#txtServiceDuration").html(this.getSelectedRecords()[0].Duration);
    //$("#txtServiceShowOnline").html(this.getSelectedRecords()[0].ShowOnline);
   
}

function onActionComplete_Service(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Service");

        var categoryData = this.getColumnByField("CategoryID").dataSource;
        var categoryDropDownListObj = $('#CategoryID').ejDropDownList({
            dataSource: categoryData,
            fields: { id: "CategoryID", value: "CategoryID", text: "Name" },
            width: "200px",
            height: "28px"
        }).data("ejDropDownList");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Service");
            categoryDropDownListObj.selectItemByValue(args.rowData.CategoryID);// SelectedCategory[0].CategoryID);
        }

        $("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        $("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });
        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Service() {
    var gridObj = $("#ServiceGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Service(args) {
    var gridObj = $("#ServiceGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Service() {
    var gridObj = $("#ServiceGrid").data("ejGrid");
    gridObj.deleteRecord("ServiceID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Service(args) {
    $.ajax({
        url: "/Service/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#ServiceGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Service(args) {
    $.ajax({
        url: "/Service/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#ServiceGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Service(args) {
    $.ajax({
        url: "/Service/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.ServiceID }),
        success: function (value) {
            $("#ServiceGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}


//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Company-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------

function onRowSelected_Company(args) {
    //$("#txtCompanyName").html(this.getSelectedRecords()[0].Name);
    //$("#txtCompanyDescription").html(this.getSelectedRecords()[0].Description);
    //$("#txtCompanyPhone").html(this.getSelectedRecords()[0].Phone);
    //$("#txtCompanyAddress").html(this.getSelectedRecords()[0].Address);
    //$("#txtCompanyCity").html(this.getSelectedRecords()[0].City);
    //$("#txtCompanyPostalCode").html(this.getSelectedRecords()[0].PostalCode);

}

function onActionComplete_Company(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Company");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Company");
        }

        //$("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        //$("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });
        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Company() {
    var gridObj = $("#CompanyGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Company(args) {
    var gridObj = $("#CompanyGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Company() {
    var gridObj = $("#CompanyGrid").data("ejGrid");
    gridObj.deleteRecord("CompanyID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Company(args) {
    $.ajax({
        url: "/Company/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#CompanyGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Company(args) {
    $.ajax({
        url: "/Company/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#CompanyGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Company(args) {
    $.ajax({
        url: "/Company/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.CompanyID }),
        success: function (value) {
            $("#CompanyGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Customer-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------


function onRowSelected_Customer(args) {
    //$("#txtCustomerFirstName").html(this.getSelectedRecords()[0].FirstName);
    //$("#txtCustomerLastName").html(this.getSelectedRecords()[0].LastName);
 

    //if ((this.getSelectedRecords()[0].StoreID) != null)
    //{
    //      var ColStore = this.getColumnByField("StoreID");
    //   var SelectedStore = ej.DataManager(ColStore.dataSource).executeLocal(ej.Query().where("StoreID", "equal", this.getSelectedRecords()[0].StoreID, true));
    //$("#txtCustomerStore").html(SelectedStore[0].Name);
    //}
    //if ((this.getSelectedRecords()[0].CompanyID) != null) {
    //var ColCompany = this.getColumnByField("CompanyID");
    //var SelectedCompany = ej.DataManager(ColCompany.dataSource).executeLocal(ej.Query().where("CompanyID", "equal", this.getSelectedRecords()[0].CompanyID, true));
    //$("#txtCustomerCompany").html(SelectedCompany[0].Name);
    //}

  
    //$("#txtCustomerPhone").html(this.getSelectedRecords()[0].Phone);
    //$("#txtCustomerEmail").html(this.getSelectedRecords()[0].Email);

    //$("#txtCustomerAddress").html(this.getSelectedRecords()[0].Address);
    //$("#txtCustomerCity").html(this.getSelectedRecords()[0].City);
    //$("#txtCustomerPostalCode").html(this.getSelectedRecords()[0].PostalCode);
    //$("#txtCustomerDiscount").html(this.getSelectedRecords()[0].Discount);
    //$("#txtCustomerNotes").html(this.getSelectedRecords()[0].Notes);
}

function onActionComplete_Customer(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Customer Info");

        var companyData = this.getColumnByField("CompanyID").dataSource;
        var companyDropDownListObj = $('#CompanyID').ejDropDownList({
            dataSource: companyData,
            fields: { id: "CompanyID", value: "CompanyID", text: "Name" },
            width: "200px",
            height: "28px"
        }).data("ejDropDownList");

        var storeData = this.getColumnByField("StoreID").dataSource;
        var storeDropDownListObj = $('#StoreID').ejDropDownList({
            dataSource: storeData,
            fields: { id: "StoreID", value: "StoreID", text: "Name" },
            width: "200px",
            height: "28px"
        }).data("ejDropDownList");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Customer Info");
            companyDropDownListObj.selectItemByValue(args.rowData.CompanyID);// SelectedCategory[0].CategoryID);
            storeDropDownListObj.selectItemByValue(args.rowData.StoreID);// SelectedCategory[0].CategoryID);
        }

        //$("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        //$("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });
        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Customer() {
    var gridObj = $("#CustomerGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Customer(args) {
    var gridObj = $("#CustomerGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Customer() {
    var gridObj = $("#CustomerGrid").data("ejGrid");
    gridObj.deleteRecord("CustomerID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Customer(args) {
    $.ajax({
        url: "/Customer/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#CustomerGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Customer(args) {
    $.ajax({
        url: "/Customer/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#CustomerGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Customer(args) {
    $.ajax({
        url: "/Customer/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.CustomerID }),
        success: function (value) {
            $("#CustomerGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Store-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------

function onRowSelected_Store(args) {
    //$("#txtStoreName").html(this.getSelectedRecords()[0].Name);
    //$("#txtStoreDescription").html(this.getSelectedRecords()[0].Description);
    //$("#txtStorePhone").html(this.getSelectedRecords()[0].Phone);
    //$("#txtStoreAddress").html(this.getSelectedRecords()[0].Address);
    //$("#txtStoreCity").html(this.getSelectedRecords()[0].City);
    //$("#txtStorePostalCode").html(this.getSelectedRecords()[0].PostalCode);

}

function onActionComplete_Store(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Store");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Store");
        }

        //$("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        //$("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });
        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Store() {
    var gridObj = $("#StoreGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Store(args) {
    var gridObj = $("#StoreGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Store() {
    var gridObj = $("#StoreGrid").data("ejGrid");
    gridObj.deleteRecord("StoreID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Store(args) {
    $.ajax({
        url: "/Store/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#StoreGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Store(args) {
    $.ajax({
        url: "/Store/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#StoreGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Store(args) {
    $.ajax({
        url: "/Store/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.StoreID }),
        success: function (value) {
            $("#CompanyGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}


//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Supplier-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------

function onRowSelected_Supplier(args) {
    //$("#txtSupplierName").html(this.getSelectedRecords()[0].Name);
    //$("#txtSupplierDescription").html(this.getSelectedRecords()[0].Description);
    //$("#txtSupplierPhone").html(this.getSelectedRecords()[0].Phone);
    //$("#txtSupplierAddress").html(this.getSelectedRecords()[0].Address);
    //$("#txtSupplierCity").html(this.getSelectedRecords()[0].City);
    //$("#txtSupplierPostalCode").html(this.getSelectedRecords()[0].PostalCode);

}

function onActionComplete_Supplier(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Supplier");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Supplier");
        }

        //$("#Price").ejCurrencyTextbox({ value: $("#Price").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        //$("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });
        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Supplier() {
    var gridObj = $("#SupplierGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Supplier(args) {
    var gridObj = $("#SupplierGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Supplier() {
    var gridObj = $("#SupplierGrid").data("ejGrid");
    gridObj.deleteRecord("SupplierID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Supplier(args) {
    $.ajax({
        url: "/Supplier/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#SupplierGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Supplier(args) {
    $.ajax({
        url: "/Supplier/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#SupplierGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Supplier(args) {
    $.ajax({
        url: "/Supplier/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.SupplierID }),
        success: function (value) {
            $("#SupplierGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

//------------------------------------------ ------------------------------------------------------------
//------------------------------------------ Staff-----------------------------------------------------
//------------------------------------------ ------------------------------------------------------------


function onRowSelected_Staff(args) {
    //$("#txtStaffFirstName").html(this.getSelectedRecords()[0].FirstName);
    //$("#txtStaffLastName").html(this.getSelectedRecords()[0].LastName);


    //if ((this.getSelectedRecords()[0].StoreID) != null) {
    //    var ColStore = this.getColumnByField("StoreID");
    //    var SelectedStore = ej.DataManager(ColStore.dataSource).executeLocal(ej.Query().where("StoreID", "equal", this.getSelectedRecords()[0].StoreID, true));
    //    $("#txtStaffStore").html(SelectedStore[0].Name);
    //}
    //if ((this.getSelectedRecords()[0].CompanyID) != null) {
    //    var ColCompany = this.getColumnByField("CompanyID");
    //    var SelectedCompany = ej.DataManager(ColCompany.dataSource).executeLocal(ej.Query().where("CompanyID", "equal", this.getSelectedRecords()[0].CompanyID, true));
    //    $("#txtStaffCompany").html(SelectedCompany[0].Name);
    //}


    //$("#txtStaffPhone").html(this.getSelectedRecords()[0].Phone);
    //$("#txtStaffEmail").html(this.getSelectedRecords()[0].Email);

    //$("#txtStaffAddress").html(this.getSelectedRecords()[0].Address);
    //$("#txtStaffCity").html(this.getSelectedRecords()[0].City);
    //$("#txtStaffPostalCode").html(this.getSelectedRecords()[0].PostalCode);
    //$("#txtStaffRole").html(this.getSelectedRecords()[0].Role);
    //$("#txtStaffCommission").html(this.getSelectedRecords()[0].Commission);
    //$("#txtStaffRate").html(this.getSelectedRecords()[0].Rate);
    ////$("#ResourceColor").ejColorPicker({ value: $("#ResourceColor").val(), width: "300px", height: "28px" });

    //$("#txtStaffResourceColor").ejColorPicker({
    //    value: this.getSelectedRecords()[0].ResourceColor, displayInline: true});

}

function onActionComplete_Staff(args) {

    if ((args.requestType == "beginedit" || args.requestType == "add") && args.model.editSettings.editMode == "dialogtemplate") {
        $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Create new Staff Info");

        var companyData = this.getColumnByField("CompanyID").dataSource;
        var companyDropDownListObj = $('#CompanyID').ejDropDownList({
            dataSource: companyData,
            fields: { id: "CompanyID", value: "CompanyID", text: "Name" },
            width: "280px",
            height: "28px"
            
        }).data("ejDropDownList");

        var storeData = this.getColumnByField("StoreID").dataSource;
        var storeDropDownListObj = $('#StoreID').ejDropDownList({
            dataSource: storeData,
            fields: { id: "StoreID", value: "StoreID", text: "Name" },
            width: "280px",
            height: "28px"
        }).data("ejDropDownList");

        if (args.requestType == "beginedit") {
            $('#' + this._id + '_dialogEdit').ejDialog("option", "title", "Update existing Staff Info");
            companyDropDownListObj.selectItemByValue(args.rowData.CompanyID);// SelectedCategory[0].CategoryID);
            storeDropDownListObj.selectItemByValue(args.rowData.StoreID);// SelectedCategory[0].CategoryID);
        }


        var roles = [{ text: "Admin", value: "Admin", selected: ($("#Role").val().indexOf("Staff") > -1 ? true : false) },
            { text: "POS", value: "POS", selected: ($("#Role").val().indexOf("POS") >-1 ? true : false) },
            { text: "Owner", value: "Owner", selected: ($("#Role").val().indexOf("Owner")>-1 ? true : false)  },
            { text: "FrontDesk", value: "FrontDesk", selected: ($("#Role").val().indexOf("FrontDesk") > -1   ? true : false) },
            { text: "Staff", value: "Staff", selected: ($("#Role").val().indexOf("Staff")> -1 ? true : false) }

        ];

          
   
        
        //, MultiSelectMode: MultiSelectModeTypes.VisualMode
        $("#Role").ejDropDownList({
            dataSource: roles, fields: {
                text: "text",
                value: "value",
                selected: "selected"
            }, showCheckbox: true,
            multiSelectMode: ej.MultiSelectMode.VisualMode,
             width: "280px"
            //multiSelectMode: ej.MultiSelectMode.Delimiter,
            //delimiterChar: ";"

});

        $("#Rate").ejCurrencyTextbox({ value: $("#Rate").val(), currencySymbol: "$", width: "116px", height: "28px", decimalPlaces: 2 });
        $("#Commission").ejCurrencyTextbox({ value: $("#Commission").val(), currencySymbol: "$", width: "280px", height: "28px", decimalPlaces: 2 });
        //$("#ResourceColor").ejColorPicker({ value: "#278787"});
        $("#ResourceColor").ejColorPicker({ value: $("#ResourceColor").val(), width: "300px", height: "28px"});

        //$("#ShowOnline").ejCheckBox({ checked: $("#ShowOnline").val() });

        //({ value: $("#ShowOnline").val(), width: "100px", height: "28px" });
    }
}

function add_Staff() {
    var gridObj = $("#StaffGrid").data("ejGrid");
    gridObj.addRecord();
}


function edit_Staff(args) {
    var gridObj = $("#StaffGrid").data("ejGrid");
    gridObj.startEdit();
}


function delete_Staff() {
    var gridObj = $("#StaffGrid").data("ejGrid");
    gridObj.deleteRecord("StaffID", gridObj.getSelectedRecords()[0]);
}


function endEdit_Staff(args) {
    $.ajax({
        url: "/Staff/Update",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#StaffGrid").ejGrid("dataSource", value);
            alert("Save Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endAdd_Staff(args) {
    $.ajax({
        url: "/Staff/Insert",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ value: args.data }),
        success: function (value) {
            $("#StaffGrid").ejGrid("dataSource", value);
            alert("Add Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });

}

function endDelete_Staff(args) {
    $.ajax({
        url: "/Staff/Remove",
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ key: args.data.StaffID }),
        success: function (value) {
            $("#StaffGrid").ejGrid("dataSource", value);
            alert("Delete Complete")
        },
        error: function (xhr) {
            alert('error');
        }
    });
}

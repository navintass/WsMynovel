<div class="row">
    <div class="col-md-12">
        <h1 style="color:red" ng-show="show_success == true">
            กำลังโหลดข้อมูล Ebook
        </h1>
        <h1 style="color:green" ng-show="show_success == false">
            ดึงข้อมูล Ebook เรียบร้อย
        </h1>
        <button class="btn btn-success" ng-disabled="show_success == true" ng-click="save_data()">Update Ebook</button>
        <h1 style="color:red" ng-show="show_all_success == true">
            กำลังโหลดข้อมูล Products
        </h1>
        <h1 style="color:green" ng-show="show_all_success == false">
            ดึงข้อมูล Products เรียบร้อย
        </h1>
        <button class="btn btn-success" ng-disabled="show_all_success == true" ng-click="save_data_all()">Update Product</button>
        <hr />
    </div>
</div>
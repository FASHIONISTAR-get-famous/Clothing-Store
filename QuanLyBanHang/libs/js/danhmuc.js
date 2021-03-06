﻿$(document).ready(function () {
    $('#form-save').validate({
        rules: {
            tenloai: "required",
        },
        messages: {
            tenloai: "Bạn phải nhập tên danh mục"
        },
    });

    $('.btn-edit').click(function () {
        var id = $(this).data('id');
        $.ajax({
            url: '/Admin/DanhMuc/layDanhMuc',
            data: {
                id: id
            },
            type: "GET",
            datatype: "json",
            success: function (response) {
                console.log("AA");
                var data = JSON.parse(response.data);
                $('#tenloai').val(data.TenLoai);
                $('#id').val(data.ID);
            }
        })
    });

    $('.btn-save').click(function () {
        if ($('#form-save').valid()) {
            var id = $('#id').val();
            var tenloai = $('#tenloai').val();

            var loaisanpham = {
                id: id,
                tenloai: tenloai
            }

            $.ajax({
                url: '/Admin/DanhMuc/Save',
                data: {
                    loaisanpham: loaisanpham
                },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        $.notify("Thành công", "success");
                    }
                    else {
                        $.notify("Thất bại", "error");
                    }
                }
            });
        }
    });

    $('.btn-delete').click(function () {
        if (confirm("Bạn có chắc là xóa không?")) {
            var id = $(this).data('id');
            $.ajax({
                url: '/Admin/DanhMuc/Delete',
                data: {
                    id: id
                },
                type: "POST",
                dataType: "json",
                success: function (response) {
                    if (response.status) {
                        $.notify("Thành công", "success");
                        setTimeout(function () {
                            window.location.reload();
                        }, 1000);
                    }
                    else {
                        $.notify("Thất bại", "error");
                    }
                }
            });
        }
    });
});
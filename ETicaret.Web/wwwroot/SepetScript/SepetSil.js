function UrunuSil(urunId) {
	$.ajax({
		url: '/Sepetler/UrunSil/',
		type: 'Post',
		data: { urunId: urunId },
		success: function (response) {
			if (response.success) {
				alert(response.message);
			}
			else {
				alert("ürün silinemedi");
			}
		},
		error: function () {
			alert("Bir hata meydana geldi");
		}
	});
}
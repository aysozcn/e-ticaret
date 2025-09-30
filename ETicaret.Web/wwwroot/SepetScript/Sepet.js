let sepetSayisi = 0

function SepetEkle(urunAdi) {
    sepetSayisi++;
    sepetSayisiGuncelle();
    urunuSepeteEkle(urunAdi);
    ekleAjax(urunAdi);//Ajax ile ürünü sepetteki tabloya ekler
    
}

function sepetSayisiGuncelle() {
    document.getElementById('sepetSayisi').innerText = sepetSayisi;
}

function urunuSepeteEkle(urunAdi) {
    const sepetListesi = document.getElementById('sepetListesi');
    const yeniUrun = document.createElement('li');
    yeniUrun.textContent = urunAdi;
    sepetListesi.appendChild(yeniUrun);
   
   
}

function ekleAjax(urunAdi) {
    $.ajax({
        url: '/Sepetler/UrunEkle',
        type: 'Post',
        data:{ urunAdi: urunAdi },
        success: function (data) {
            alert(data);
        },
        error: function (error) {
            alert(error);
        }
    });
    // Ürün bilgileri
    var urun = {
        id: 1,
        ad: " ",
        fiyat: 50.00
    };

    // Sepet kontrolü
    if (!localStorage.getItem('sepet')) {
        localStorage.setItem('sepet', JSON.stringify([]));
    }

    // Sepete ekleme
    var sepet = JSON.parse(localStorage.getItem('sepet'));
    sepet.push(urun);
    localStorage.setItem('sepet', JSON.stringify(sepet));

    console.log("Ürün sepete eklendi!");

}

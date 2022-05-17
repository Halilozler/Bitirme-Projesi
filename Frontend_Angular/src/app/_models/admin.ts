export class Ogrenci{
    id!: number;
    ogrenci_Adi!: string;
    ogrenci_Soyadi!: string;
    ogrenci_No!: string;
    ogrenci_Tc!: string;
    ogrenci_Sifre!: string;
    bolum_Id!: number;
    durum?: boolean;
}

export class Ogretim{
    id!: number;
    ogretim_Adi!: string;
}

export class Sınıf{
    id!: number;
    sinif_Adi!: string;
}

export class Bolum{
    bolumId!: number;
    bolumAd!: string;
}

export class Ogretmen{
    id!: number;
    ogretmen_Adi!: string;
    ogretmen_Soyadi!: string;
    ogretmen_Tc!: string;
    ogretmen_Sifre!: string;
    bolum_Id!: number;
    durum!: boolean;
}

export class Ders{
    dersId!: number;
    dersKodu!: string;
    dersAdi!: string;
    durum!: boolean;
    ogretmen_Id!: number;
    bolum_Id!: number;
    ogretim_Id!: number;
    sinif_Id!: number;
    ogretmenAd?: string;
    ogretmenSoyad?: string;
    bolumAd?: string;
    ogretimAd?: string;
    sinifAd?: string;
}
export class DersEkle{
    ders_Kodu!: string;
    ders_Adi!: string;
    durum!: boolean;
    ogretmen_Id!: number;
    bolum_Id!: number;
    ogretim_Id!: number;
    sinif_Id!: number;
}

export class Bildirim{
    id!: number;
    bildirimKonu_Id!: number;
    dersSaat_Id!: number;
    eskiSaat?: Date;
    yeniSaat?: Date;
    yeniSinif_Id?: Date;
    durum?: boolean;
    olusturuldugu_Tarih!: Date;
}

export class DersSaati{
    tarih!: Date;
    ders_id!: number;
}
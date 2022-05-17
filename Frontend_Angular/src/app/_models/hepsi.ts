export class Yoklama{
    dersSaat_Id!: number;
    yapildigiTarih!: Date;
    katilanOgrenci!: number;
    ogrenciYoklamaKontrol?: boolean;
}

export class GelecekDers{
    dersSaat_id?: number;
    dersKodu?: string;
    dersAdi?: string;
    sinifi?: string;
    tarih!: Date;
}

export class Bildirim{
    baslik!: string;
    ders_Kodu!: string;
    ders_Adi!: string;
    olusturulduguTarih!: Date;
    dersSaati!: Date;
    yeniSaati?: Date;
    yeniSinifi?: string;
}

export class AlınanDers{
    id!: number;
    ogrenci_Id!: number;
    ders_Id!: number;
}

export class YoklamaDto{
    numara?: number;
    ogrenciId?: number;
    yoklamaId?: number;
    ogrenciAd!: string;
    ogrenciSoyad!: string;
    durum?: boolean;
}

export class Auth{
    kullaniciadi!: string;
    sifre!: string;
}

export class DersYoklaması{
    dersiAlanlar!: AlınanDers[];
    derseGelenler!: YoklamaDto[];
    derseGelmeyenler!: YoklamaDto[];
}

export class deCode{
    id!: number;
    rolu!: string;
}

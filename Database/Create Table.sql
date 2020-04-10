create TABLE Lokasi(
    LokasiID number(10) NOT NULL,
    Deskripsi VARCHAR2(255),
    CONSTRAINT lokasi_pk PRIMARY KEY (LokasiID)
);

create table test.Data(
    DataID number(10) NOT NULL,
    Judul VARCHAR2(45) Not NULL,
    Keterangan VARCHAR2(255),
    Foto VARCHAR2(255),
    LokasiID number(10) NOT NULL,
    CONSTRAINT data_pk PRIMARY KEY (DataID),
    CONSTRAINT lokasi_fk 
        FOREIGN KEY(LokasiID)
        REFERENCES Lokasi(LokasiID)
);

create TABLE test.Lokasi(
    LokasiID number(10) NOT NULL
    Deskripsi VARCHAR2(255),
    CONSTANT lokasi_pk PRIMARY_KEY(LokasiID)
);


create table test.Data(
    DataID number(10) NOT NULL,
    Judul VARCHAR2(45) Not NULL,
    Keterangan VARCHAR2(255),
    Foto VARCHAR2(255),
    LokasiID number(10) NOT NULL,
    CONSTANT data_pk PRIMARY_KEY (DataID),
    CONSTANT lokasi_fk 
        FOREIGN KEY(LokasiID)
        REFERENCE Lokasi(LokasiID)
);
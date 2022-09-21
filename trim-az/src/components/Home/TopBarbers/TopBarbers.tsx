import { Swiper, SwiperSlide } from "swiper/react";
import { Pagination, Navigation } from "swiper";
import SectionHeader from "../../UI/section/SectionHeader";
import BarberSlide from "./BarberSlide";
import SwiperPrev from "../../UI/swiper/SwiperPrev";
import SwiperNext from "../../UI/swiper/SwiperNext";
//import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
//import axios from "axios";

import "swiper/css";
import "swiper/css/pagination";
import "swiper/css/navigation";

//const initialState = {
//    loading: false,
//    users: [],
//    error: "",
//};

//Generates pending,fulfilled and rejected action types

//export const fetchTopBarbers = createAsyncThunk("api/products", () => {
//    return axios
//        .get("https://jsonplaceholder.typicode.com/todos/1")
//        .then((response) => response.data.map((tt:any) => tt["id"]));
//});

const sliderItems = [
    {
        id: "s1",
        imageSrc: require("../../../assets/images/1077-500x500.jpg"),
        name: "Sinan Engin",
        rating: 4.0,
    },
    {
        id: "s2",
        imageSrc: require("../../../assets/images/555-500x500.jpg"),
        name: "Ahmet Çakar",
        rating: 3.0,
    },
    {
        id: "s3",
        imageSrc: require("../../../assets/images/612-500x500.jpg"),
        name: "Ertem Şener",
        rating: 2.0,
    },
    {
        id: "s4",
        imageSrc: require("../../../assets/images/685-500x500.jpg"),
        name: "Abdülkerim Durmaz",
        rating: 5.0,
    },
    {
        id: "s5",
        imageSrc: require("../../../assets/images/555-500x500.jpg"),
        name: "Rasim Ozan Kütahyalı",
        rating: 4.5,
    },
    {
        id: "s6",
        imageSrc: require("../../../assets/images/612-500x500.jpg"),
        name: "Adil Heybetov",
        rating: 5.0,
    },
    {
        id: "s7",
        imageSrc: require("../../../assets/images/685-500x500.jpg"),
        name: "Togrul Heybetov",
        rating: 3.6,
    },
    {
        id: "s8",
        imageSrc: require("../../../assets/images/1077-500x500.jpg"),
        name: "Zekeriya Öz",
        rating: 1.1,
    },
];

const TopBarbers = () => {
    return (
        <section id="topBarbers">
            <div className="container">
                <SectionHeader text="Top barbers" />
                <div className="slider_holder position-relative">
                    <div className="on_slider_nav">
                        <SwiperPrev className="absolute-nav" />
                        <SwiperNext className="absolute-nav" />
                    </div>
                    <Swiper
                        breakpoints={{
                            576: { slidesPerView: 2 },
                            768: { slidesPerView: 3 },
                            992: { slidesPerView: 4 },
                            1200: { slidesPerView: 5 },
                        }}
                        spaceBetween={24}
                        navigation={{
                            prevEl: ".on_slider_nav .swiper-custom-prev",
                            nextEl: ".on_slider_nav .swiper-custom-next",
                        }}
                        loop={true}
                        modules={[Pagination, Navigation]}
                        onSlideChange={() => console.log("slide change")}
                        onSwiper={(swiper) => console.log(swiper)}
                    >
                        {sliderItems.map((item) => (
                            <SwiperSlide key={item.id}>
                                <BarberSlide
                                    imageSrc={item.imageSrc}
                                    name={item.name}
                                    rating={item.rating}
                                />
                            </SwiperSlide>
                        ))}
                    </Swiper>
                </div>
            </div>
        </section>
    );
};

export default TopBarbers;

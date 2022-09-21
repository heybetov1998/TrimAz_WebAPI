import SectionHeader from "../../UI/section/SectionHeader";
import NavigationAbove from "../../UI/swiper/NavigationAbove";
import { Swiper, SwiperSlide } from "swiper/react";
import { Navigation, Pagination } from "swiper";
import Card from "../../UI/Card";

const DUMMY_BARBERSHOPS = [
    {
        id: 1,
        title: "Balaeli barber",
        price: 15,
        afterPrice: "-dan başlayaraq",
        location: "Sovetski, Baku",
        image: {
            src: require("../../../assets/images/1077-500x500.jpg"),
            alt: "Barbershop image",
        },
    },
    {
        id: 2,
        title: "Boycut",
        price: 25,
        afterPrice: "-dan başlayaraq",
        location: "28 May, Baku",
        image: {
            src: require("../../../assets/images/555-500x500.jpg"),
            alt: "Barbershop image",
        },
    },
    {
        id: 3,
        title: "Teymurun yeri",
        price: 15,
        afterPrice: "-dan başlayaraq",
        location: "Çin səfirliyinin arxası",
        image: {
            src: require("../../../assets/images/612-500x500.jpg"),
            alt: "Barbershop image",
        },
    },
    {
        id: 4,
        title: "Öz bərbərim",
        price: 5,
        afterPrice: "-dan başlayaraq",
        location: "Tarqovu",
        image: {
            src: require("../../../assets/images/685-500x500.jpg"),
            alt: "Barbershop image",
        },
    },
    {
        id: 5,
        title: "Figaro",
        price: 10,
        afterPrice: "-dan başlayaraq",
        location: "Azadlıq metrosu, Baku",
        image: {
            src: require("../../../assets/images/intro.jpg"),
            alt: "Barbershop image",
        },
    },
];

const BestBarbershops = () => {
    return (
        <section id="bestBarbershops">
            <div className="container">
                <SectionHeader text="Best Barbershops" />

                <div className="slider_holder position-relative">
                    <NavigationAbove id="bestBarbershopNav" />
                    <Swiper
                        breakpoints={{
                            576: { slidesPerView: 2, slidesPerGroup: 2 },
                            768: { slidesPerView: 2, slidesPerGroup: 2 },
                            992: { slidesPerView: 3, slidesPerGroup: 3 },
                            1200: { slidesPerView: 4, slidesPerGroup: 4 },
                        }}
                        spaceBetween={24}
                        navigation={{
                            prevEl: "#bestBarbershopNav .swiper-custom-prev",
                            nextEl: "#bestBarbershopNav .swiper-custom-next",
                        }}
                        loop={true}
                        pagination={{
                            el: ".paginationBarbershop",
                            clickable: true,
                            renderBullet: (index, className) => {
                                return `<span class="${className}"></span>`;
                            },
                        }}
                        modules={[Pagination, Navigation]}
                        onSlideChange={() => console.log("slide change")}
                        onSwiper={(swiper) => console.log(swiper)}
                    >
                        {DUMMY_BARBERSHOPS.map((bshop) => (
                            <SwiperSlide key={bshop.id}>
                                <Card
                                    title={bshop.title}
                                    price={bshop.price}
                                    image={bshop.image}
                                    location={bshop.location}
                                />
                            </SwiperSlide>
                        ))}
                    </Swiper>
                    <div className="custom-pagination paginationBarbershop"></div>
                </div>
            </div>
        </section>
    );
};

export default BestBarbershops;

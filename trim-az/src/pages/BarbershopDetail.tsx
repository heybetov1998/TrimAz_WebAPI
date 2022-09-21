import { Link, useParams } from "react-router-dom";
import BarberCard from "../components/Cards/BarberCard";
import CardFrame from "../components/UI/CardFrame";
import StandartCheckbox from "../components/UI/Checkboxes/StandartCheckbox";
import Gallery from "../components/UI/Gallery";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import Map from "../components/UI/Map";
import Reviews from "../components/UI/Reviews/Reviews";
import SectionHeader from "../components/UI/section/SectionHeader";
import SectionPartName from "../components/UI/section/SectionPartName";

const custBarber = {
    id: "barber1",
    name: "Teymur badirbayli",
    image: {
        src: require("../assets/images/685-500x500.jpg"),
    },
    rating: 4.5,
};

type ImageType = {
    id: string | number;
    src: any;
    alt?: string;
};

const images: ImageType[] = [
    { id: "img1", src: require("../assets/images/555-500x500.jpg") },
    { id: "img2", src: require("../assets/images/1077-500x500.jpg") },
    { id: "img3", src: require("../assets/images/612-500x500.jpg") },
    { id: "img4", src: require("../assets/images/685-500x500.jpg") },
    { id: "img5", src: require("../assets/images/intro.jpg") },
];

const BarbershopDetail = () => {
    const params = useParams();
    const { id } = params;

    console.log(id);

    return (
        <section id="barbershopDetail">
            <div className="container">
                <SectionHeader text="Barbershop name here" />
                <Gallery images={images} />
                <div className="our_barbers">
                    <SectionPartName text="Our Barbers" />
                    <Row>
                        <Column md={6} lg={4} xl={4}>
                            <Link
                                to={`/barbers/${custBarber.id}`}
                                className="card_holder"
                            >
                                <BarberCard barber={custBarber} />
                            </Link>
                        </Column>
                    </Row>
                </div>
                <div className="our_services">
                    <SectionPartName text="Our Services" />
                    <Row>
                        <Column md={6} lg={4} xl={3}>
                            <CardFrame className="services_list_item">
                                <StandartCheckbox
                                    text="test"
                                    isDisabled
                                    isChecked
                                />
                            </CardFrame>
                        </Column>
                    </Row>
                </div>
                <div className="our_location">
                    <SectionPartName text="Our Location" />
                    <Map lat={40.3773237} lng={49.8540028} />
                </div>
                <div className="our_reviews">
                    <SectionPartName text="Comments &amp; Reviews" />
                    <Reviews />
                </div>
            </div>
        </section>
    );
};

export default BarbershopDetail;

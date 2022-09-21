import BarberInfo from "../components/BarberDetail/BarberInfo";
import MyServices from "../components/BarberDetail/MyServices";
import Portfolio from "../components/BarberDetail/Portfolio";
import Videos from "../components/BarberDetail/Videos";
import Column from "../components/UI/grid/Column";
import Row from "../components/UI/grid/Row";
import Reviews from "../components/UI/Reviews/Reviews";

const DUMMY_IMAGES = [
    { src: require("../assets/images/685-500x500.jpg"), alt: "test" },
    { src: require("../assets/images/612-500x500.jpg"), alt: "heyy" },
    { src: require("../assets/images/1077-500x500.jpg"), alt: "yoo" },
    { src: require("../assets/images/555-500x500.jpg"), alt: "fion" },
];

const BarberDetail = () => (
    <section id="barbershopDetail">
        <div className="container">
            <Row>
                <Column className="order-1 order-md-0" md={8} lg={9} xl={9}>
                    <Portfolio images={DUMMY_IMAGES} />
                    <MyServices />
                    <Videos />
                    <Reviews />
                </Column>
                <Column className="order-0 order-md-1" md={4} lg={3} xl={3}>
                    <BarberInfo />
                </Column>
            </Row>
        </div>
    </section>
);

export default BarberDetail;

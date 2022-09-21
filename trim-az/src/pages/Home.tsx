import BestBarbershops from "../components/Home/BestBarbershops/BestBarbershops";
import Intro from "../components/Home/Intro";
import LatestProducts from "../components/Home/LatestProducts";
import TopBarbers from "../components/Home/TopBarbers/TopBarbers";

const Home = () => {
    return (
        <>
            <Intro />
            <TopBarbers />
            <LatestProducts />
            <BestBarbershops />
        </>
    );
};

export default Home;

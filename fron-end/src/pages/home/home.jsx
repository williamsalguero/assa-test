import React from "react";
import "./Home.css";
import Header from "../../components/header/header";

const Home = () => {
  return (
    <div className="home__container container">
      <section>
        <Header showNav={true} />
      </section>
    </div>
  );
};

export default Home;

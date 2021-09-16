const Footer = () => {
  const content = (
    <span>
      <span className="fw-bold">DISCLAIMER: </span>
      <span className="fst-italic">
        I do not own any data displayed here, nor I do not any relationship with
        Activision. All the data is coming from{" "}
        <a href="https://callofduty.fandom.com/wiki/Call_of_Duty_Wiki">
          Call of Duty Wiki
        </a>
        .
      </span>
    </span>
  );

  return (
    <div className="text-center">
      <p className="disclaimer d-md-none">{content}</p>
      <p className="d-none d-md-block disclaimer-md">{content}</p>
    </div>
  );
};

export default Footer;

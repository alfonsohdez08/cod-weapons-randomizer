const Footer = () => {
  const content = (
    <span>
      <span className="fw-bold">DISCLAIMER: </span>
      <span className="fst-italic">
        This App is not endorsed by Activision and its subsidiaries, nor the
        data displayed here belongs to the App developer. All the data is coming
        from{" "}
        <a
          href="https://callofduty.fandom.com/wiki/Call_of_Duty_Wiki"
          className="text-white"
        >
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

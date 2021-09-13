const gitHubRepoUrl = "https://github.com/alfonsohdez08/cod-weapons-randomizer";

const Header = () => (
  <div className="d-flex flex-column">
    <div className="d-flex flex-row-reverse">
      <div className="p-2">
        <a href={gitHubRepoUrl}>
          <img
            src="/octocat_white_and_black.png"
            alt="GitHub logo"
            className="github-logo"
          />
        </a>
      </div>
    </div>
    <h2 className="text-center display-2 fw-bold">COD Loadout Randomizer</h2>
  </div>
);

export default Header;

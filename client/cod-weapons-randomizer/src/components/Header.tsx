const gitHubRepoUrl = "https://github.com/alfonsohdez08/cod-weapons-randomizer";

const Header = () => (
  <div className="d-flex flex-column">
    <div className="d-flex flex-row-reverse">
      <div className="p-2">
        <a href={gitHubRepoUrl}>
          <GitHubImage className="github-logo d-sm-none" />
          <GitHubImage className="github-logo-sm d-none d-sm-inline-block" />
        </a>
      </div>
    </div>
    <h2 className="text-center display-2 fw-bold">COD Loadout Randomizer</h2>
  </div>
);

const GitHubImage = ({ className }: { className: string }) => (
  <img src="/octocat.png" alt="GitHub logo" className={className} />
);

export default Header;

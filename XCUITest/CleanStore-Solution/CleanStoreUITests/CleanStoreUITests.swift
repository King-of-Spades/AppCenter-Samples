import XCTest

class CleanStoreUITests: XCTestCase {
        
    override func setUp() {
        super.setUp()
        
        // Put setup code here. This method is called before the invocation of each test method in the class.
        
        // In UI tests it is usually best to stop immediately when a failure occurs.
        continueAfterFailure = false
        // UI tests must launch the application that they test. Doing this in setup will make sure it happens for each test method.
        XCUIApplication().launch()

        // In UI tests it’s important to set the initial state - such as interface orientation - required for your tests before they run. The setUp method is a good place to do this.
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }
    
    func testAddOrder() {
        
        let app = XCUIApplication()
        waitAndTap(element: app.navigationBars["List Orders"].buttons["Add"])
        
        let tablesQuery = app.tables
        let textField = tablesQuery.cells.containing(.staticText, identifier:"First Name").children(matching: .textField).element
        waitAndTap(element: textField)
        textField.typeText("Simon")
        
        let textField2 = tablesQuery.children(matching: .cell).element(boundBy: 7).children(matching: .textField).element
        waitAndTap(element: textField2)
        textField2.typeText("CA")
        waitAndTap(element: app.navigationBars.buttons["Save"])
    }
    
}

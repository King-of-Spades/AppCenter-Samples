
import XCTest

extension XCTestCase {
    func waitAndTap(element:XCUIElement, timeout:Float = 5.0) {
        /*
         Need to ensure element both exists and is hittable
         */
        let exists:NSPredicate = NSPredicate.init(format:"exists == true && hittable == true")
        expectation(for: exists, evaluatedWith: element, handler: nil)
        waitForExpectations(timeout: TimeInterval(timeout), handler: nil)
        element.tap()
    }
    
    func waitFor(element:XCUIElement, timeout:Float = 5.0) {
        /*
         Only going to verify that element exists
         */
        let exists:NSPredicate = NSPredicate.init(format:"exists == true")
        expectation(for: exists, evaluatedWith: element, handler: nil)
        waitForExpectations(timeout: TimeInterval(timeout), handler: nil)
    }
}
